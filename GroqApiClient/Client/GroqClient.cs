using System.Text;
using System.Text.Json;

namespace GroqApiClient.Client;

public class GroqClient : IGroqClient
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public GroqClient(HttpClient httpClient)
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://api.groq.com/")
        };
        _apiKey = Environment.GetEnvironmentVariable("GROQ_API_KEY") ?? throw new ArgumentNullException("GROQ_API_KEY environment variable is not set");
    }

    public async Task<HttpResponseMessage> ChatCompletions(string query)
    {
        var payload = new
        {
            messages = new[]
            {
                new
                {
                    role = "user",
                    content = "What are the most popular programming languages?"
                }
            },
            model = "llama3-8b-8192"
        };

        var serializedContent = JsonSerializer.Serialize(payload);
        var stringContent = new StringContent(serializedContent, Encoding.UTF8, "application/json");
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer ${_apiKey}");
        return await _httpClient.PostAsync("openai/v1/chat/completions", stringContent);
    }
}