using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using GroqApiClient.Models;

namespace GroqApiClient.Client;

/// <summary>
/// Client for interacting with the Groq API.
/// </summary>
public class GroqClient : IGroqClient
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
    };

    /// <summary>
    /// Initializes a new instance of the GroqClient class using an API key from environment variables.
    /// </summary>
    /// <param name="httpClient">Optional HttpClient instance. If not provided, a new one will be created.</param>
    /// <exception cref="ArgumentNullException">Thrown when GROQ_API_KEY environment variable is not set.</exception>
    public GroqClient(HttpClient? httpClient = null)
        : this(Environment.GetEnvironmentVariable("GROQ_API_KEY") 
            ?? throw new ArgumentNullException("GROQ_API_KEY", "GROQ_API_KEY environment variable is not set"), 
            httpClient)
    {
    }

    /// <summary>
    /// Initializes a new instance of the GroqClient class with a specified API key.
    /// </summary>
    /// <param name="apiKey">The Groq API key.</param>
    /// <param name="httpClient">Optional HttpClient instance. If not provided, a new one will be created.</param>
    /// <exception cref="ArgumentNullException">Thrown when apiKey is null or empty.</exception>
    public GroqClient(string apiKey, HttpClient? httpClient = null)
    {
        if (string.IsNullOrWhiteSpace(apiKey))
            throw new ArgumentNullException(nameof(apiKey), "API key cannot be null or empty");

        _apiKey = apiKey;
        _httpClient = httpClient ?? new HttpClient();
        
        if (_httpClient.BaseAddress == null)
        {
            _httpClient.BaseAddress = new Uri("https://api.groq.com/openai/v1/");
        }

        if (!_httpClient.DefaultRequestHeaders.Contains("Authorization"))
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
        }
    }

    /// <summary>
    /// Creates a chat completion using the specified request.
    /// </summary>
    /// <param name="request">The chat completion request.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The chat completion response.</returns>
    /// <exception cref="ArgumentNullException">Thrown when request is null.</exception>
    /// <exception cref="HttpRequestException">Thrown when the API request fails.</exception>
    public async Task<ChatCompletionResponse> CreateChatCompletionAsync(
        ChatCompletionRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        var response = await _httpClient.PostAsJsonAsync(
            "chat/completions",
            request,
            JsonOptions,
            cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync(cancellationToken);
            ErrorResponse? error = null;
            
            try
            {
                error = JsonSerializer.Deserialize<ErrorResponse>(errorContent, JsonOptions);
            }
            catch { }

            var errorMessage = error?.Error?.Message ?? $"API request failed with status code {response.StatusCode}";
            throw new HttpRequestException($"Groq API error: {errorMessage}", null, response.StatusCode);
        }

        var result = await response.Content.ReadFromJsonAsync<ChatCompletionResponse>(JsonOptions, cancellationToken);
        return result ?? throw new InvalidOperationException("Failed to deserialize response");
    }

    /// <summary>
    /// Creates a streaming chat completion using the specified request.
    /// </summary>
    /// <param name="request">The chat completion request.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>An async enumerable of chat completion chunks.</returns>
    /// <exception cref="ArgumentNullException">Thrown when request is null.</exception>
    /// <exception cref="HttpRequestException">Thrown when the API request fails.</exception>
    public async IAsyncEnumerable<ChatCompletionChunk> CreateChatCompletionStreamAsync(
        ChatCompletionRequest request,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        request.Stream = true;

        var requestMessage = new HttpRequestMessage(HttpMethod.Post, "chat/completions")
        {
            Content = JsonContent.Create(request, options: JsonOptions)
        };

        var response = await _httpClient.SendAsync(
            requestMessage,
            HttpCompletionOption.ResponseHeadersRead,
            cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync(cancellationToken);
            ErrorResponse? error = null;
            
            try
            {
                error = JsonSerializer.Deserialize<ErrorResponse>(errorContent, JsonOptions);
            }
            catch { }

            var errorMessage = error?.Error?.Message ?? $"API request failed with status code {response.StatusCode}";
            throw new HttpRequestException($"Groq API error: {errorMessage}", null, response.StatusCode);
        }

        using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        using var reader = new StreamReader(stream, System.Text.Encoding.UTF8);

        while (!reader.EndOfStream && !cancellationToken.IsCancellationRequested)
        {
            var line = await reader.ReadLineAsync();
            
            if (cancellationToken.IsCancellationRequested)
                break;
            
            if (string.IsNullOrWhiteSpace(line))
                continue;

            if (!line.StartsWith("data: "))
                continue;

            var data = line["data: ".Length..];
            
            if (data == "[DONE]")
                break;

            ChatCompletionChunk? chunk = null;
            try
            {
                chunk = JsonSerializer.Deserialize<ChatCompletionChunk>(data, JsonOptions);
            }
            catch (JsonException)
            {
                continue;
            }

            if (chunk != null)
                yield return chunk;
        }
    }

    /// <summary>
    /// Lists all available models.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The model list response.</returns>
    /// <exception cref="HttpRequestException">Thrown when the API request fails.</exception>
    public async Task<ModelListResponse> ListModelsAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync("models", cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync(cancellationToken);
            ErrorResponse? error = null;
            
            try
            {
                error = JsonSerializer.Deserialize<ErrorResponse>(errorContent, JsonOptions);
            }
            catch { }

            var errorMessage = error?.Error?.Message ?? $"API request failed with status code {response.StatusCode}";
            throw new HttpRequestException($"Groq API error: {errorMessage}", null, response.StatusCode);
        }

        var result = await response.Content.ReadFromJsonAsync<ModelListResponse>(JsonOptions, cancellationToken);
        return result ?? throw new InvalidOperationException("Failed to deserialize response");
    }
}