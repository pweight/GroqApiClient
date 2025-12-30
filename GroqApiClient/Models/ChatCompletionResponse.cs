using System.Text.Json.Serialization;

namespace GroqApiClient.Models;

/// <summary>
/// Response from a chat completion request.
/// </summary>
public class ChatCompletionResponse
{
    /// <summary>
    /// Unique identifier for this completion.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Object type (always "chat.completion").
    /// </summary>
    [JsonPropertyName("object")]
    public string Object { get; set; } = string.Empty;

    /// <summary>
    /// Unix timestamp of when the completion was created.
    /// </summary>
    [JsonPropertyName("created")]
    public long Created { get; set; }

    /// <summary>
    /// The model used for the completion.
    /// </summary>
    [JsonPropertyName("model")]
    public string Model { get; set; } = string.Empty;

    /// <summary>
    /// The list of completion choices.
    /// </summary>
    [JsonPropertyName("choices")]
    public List<ChatChoice> Choices { get; set; } = new();

    /// <summary>
    /// Usage statistics for the completion request.
    /// </summary>
    [JsonPropertyName("usage")]
    public Usage? Usage { get; set; }

    /// <summary>
    /// System fingerprint for the backend configuration.
    /// </summary>
    [JsonPropertyName("system_fingerprint")]
    public string? SystemFingerprint { get; set; }

    /// <summary>
    /// Groq-specific metadata about the request processing.
    /// </summary>
    [JsonPropertyName("x_groq")]
    public GroqMetadata? XGroq { get; set; }
}
