using GroqApiClient.Models;

namespace GroqApiClient.Client;

/// <summary>
/// Interface for interacting with the Groq API.
/// </summary>
public interface IGroqClient
{
    /// <summary>
    /// Creates a chat completion using the specified request.
    /// </summary>
    /// <param name="request">The chat completion request.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The chat completion response.</returns>
    Task<ChatCompletionResponse> CreateChatCompletionAsync(
        ChatCompletionRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a streaming chat completion using the specified request.
    /// </summary>
    /// <param name="request">The chat completion request.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>An async enumerable of chat completion chunks.</returns>
    IAsyncEnumerable<ChatCompletionChunk> CreateChatCompletionStreamAsync(
        ChatCompletionRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists all available models.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The model list response.</returns>
    Task<ModelListResponse> ListModelsAsync(CancellationToken cancellationToken = default);
}