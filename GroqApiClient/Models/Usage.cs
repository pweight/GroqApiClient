using System.Text.Json.Serialization;

namespace GroqApiClient.Models;

/// <summary>
/// Token usage statistics for a completion request.
/// </summary>
public class Usage
{
    /// <summary>
    /// Number of tokens in the prompt.
    /// </summary>
    [JsonPropertyName("prompt_tokens")]
    public int PromptTokens { get; set; }

    /// <summary>
    /// Number of tokens in the completion.
    /// </summary>
    [JsonPropertyName("completion_tokens")]
    public int CompletionTokens { get; set; }

    /// <summary>
    /// Total number of tokens used.
    /// </summary>
    [JsonPropertyName("total_tokens")]
    public int TotalTokens { get; set; }

    /// <summary>
    /// Time spent in the prompt queue (Groq-specific).
    /// </summary>
    [JsonPropertyName("queue_time")]
    public double? QueueTime { get; set; }

    /// <summary>
    /// Time spent processing the prompt (Groq-specific).
    /// </summary>
    [JsonPropertyName("prompt_time")]
    public double? PromptTime { get; set; }

    /// <summary>
    /// Time spent generating the completion (Groq-specific).
    /// </summary>
    [JsonPropertyName("completion_time")]
    public double? CompletionTime { get; set; }

    /// <summary>
    /// Total time for the request (Groq-specific).
    /// </summary>
    [JsonPropertyName("total_time")]
    public double? TotalTime { get; set; }
}
