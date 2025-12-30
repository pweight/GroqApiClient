using System.Text.Json.Serialization;

namespace GroqApiClient.Models;

/// <summary>
/// Response chunk from a streaming chat completion request.
/// </summary>
public class ChatCompletionChunk
{
    /// <summary>
    /// Unique identifier for this completion.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Object type (always "chat.completion.chunk").
    /// </summary>
    [JsonPropertyName("object")]
    public string Object { get; set; } = string.Empty;

    /// <summary>
    /// Unix timestamp of when the chunk was created.
    /// </summary>
    [JsonPropertyName("created")]
    public long Created { get; set; }

    /// <summary>
    /// The model used for the completion.
    /// </summary>
    [JsonPropertyName("model")]
    public string Model { get; set; } = string.Empty;

    /// <summary>
    /// The list of completion choices in this chunk.
    /// </summary>
    [JsonPropertyName("choices")]
    public List<ChatChoiceDelta> Choices { get; set; } = new();

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

/// <summary>
/// A completion choice delta in a streaming response.
/// </summary>
public class ChatChoiceDelta
{
    /// <summary>
    /// The index of this choice.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; set; }

    /// <summary>
    /// The delta message content.
    /// </summary>
    [JsonPropertyName("delta")]
    public ChatMessageDelta? Delta { get; set; }

    /// <summary>
    /// The reason the completion finished (only in the last chunk).
    /// </summary>
    [JsonPropertyName("finish_reason")]
    public string? FinishReason { get; set; }

    /// <summary>
    /// Log probabilities for the generated tokens.
    /// </summary>
    [JsonPropertyName("logprobs")]
    public object? Logprobs { get; set; }
}

/// <summary>
/// Delta message content in a streaming response.
/// </summary>
public class ChatMessageDelta
{
    /// <summary>
    /// The role of the message author (only in the first chunk).
    /// </summary>
    [JsonPropertyName("role")]
    public string? Role { get; set; }

    /// <summary>
    /// The content delta.
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; set; }

    /// <summary>
    /// Tool calls delta (for assistant messages).
    /// </summary>
    [JsonPropertyName("tool_calls")]
    public List<ToolCall>? ToolCalls { get; set; }
}
