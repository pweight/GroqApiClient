using System.Text.Json.Serialization;

namespace GroqApiClient.Models;

/// <summary>
/// Represents a message in a chat conversation.
/// </summary>
public class ChatMessage
{
    /// <summary>
    /// The role of the message author. Can be "system", "user", "assistant", or "tool".
    /// </summary>
    [JsonPropertyName("role")]
    public string Role { get; set; } = string.Empty;

    /// <summary>
    /// The content of the message.
    /// </summary>
    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// Optional name of the author of this message.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Tool calls that the model wants to make (for assistant messages).
    /// </summary>
    [JsonPropertyName("tool_calls")]
    public List<ToolCall>? ToolCalls { get; set; }

    /// <summary>
    /// Tool call ID (for tool messages).
    /// </summary>
    [JsonPropertyName("tool_call_id")]
    public string? ToolCallId { get; set; }
}
