using System.Text.Json.Serialization;

namespace GroqApiClient.Models;

/// <summary>
/// Request for creating a chat completion.
/// </summary>
public class ChatCompletionRequest
{
    /// <summary>
    /// The messages to generate completions for.
    /// </summary>
    [JsonPropertyName("messages")]
    public List<ChatMessage> Messages { get; set; } = new();

    /// <summary>
    /// The model to use for the completion.
    /// </summary>
    [JsonPropertyName("model")]
    public string Model { get; set; } = "llama3-8b-8192";

    /// <summary>
    /// Sampling temperature between 0 and 2. Higher values make output more random.
    /// </summary>
    [JsonPropertyName("temperature")]
    public double? Temperature { get; set; }

    /// <summary>
    /// Maximum number of tokens to generate.
    /// </summary>
    [JsonPropertyName("max_tokens")]
    public int? MaxTokens { get; set; }

    /// <summary>
    /// Nucleus sampling parameter. Alternative to temperature.
    /// </summary>
    [JsonPropertyName("top_p")]
    public double? TopP { get; set; }

    /// <summary>
    /// Whether to stream the response.
    /// </summary>
    [JsonPropertyName("stream")]
    public bool? Stream { get; set; }

    /// <summary>
    /// Stop sequences where the API will stop generating tokens.
    /// </summary>
    [JsonPropertyName("stop")]
    public List<string>? Stop { get; set; }

    /// <summary>
    /// Number of completions to generate.
    /// </summary>
    [JsonPropertyName("n")]
    public int? N { get; set; }

    /// <summary>
    /// Penalize new tokens based on their frequency in the text so far.
    /// </summary>
    [JsonPropertyName("frequency_penalty")]
    public double? FrequencyPenalty { get; set; }

    /// <summary>
    /// Penalize new tokens based on whether they appear in the text so far.
    /// </summary>
    [JsonPropertyName("presence_penalty")]
    public double? PresencePenalty { get; set; }

    /// <summary>
    /// Tools available for the model to use.
    /// </summary>
    [JsonPropertyName("tools")]
    public List<Tool>? Tools { get; set; }

    /// <summary>
    /// Control how the model responds to tool calls.
    /// </summary>
    [JsonPropertyName("tool_choice")]
    public object? ToolChoice { get; set; }

    /// <summary>
    /// A unique identifier for the end-user.
    /// </summary>
    [JsonPropertyName("user")]
    public string? User { get; set; }
}
