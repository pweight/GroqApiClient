using System.Text.Json.Serialization;

namespace GroqApiClient.Models;

/// <summary>
/// A completion choice in the response.
/// </summary>
public class ChatChoice
{
    /// <summary>
    /// The index of this choice.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; set; }

    /// <summary>
    /// The generated message.
    /// </summary>
    [JsonPropertyName("message")]
    public ChatMessage? Message { get; set; }

    /// <summary>
    /// The reason the completion finished.
    /// </summary>
    [JsonPropertyName("finish_reason")]
    public string? FinishReason { get; set; }

    /// <summary>
    /// Log probabilities for the generated tokens.
    /// </summary>
    [JsonPropertyName("logprobs")]
    public object? Logprobs { get; set; }
}
