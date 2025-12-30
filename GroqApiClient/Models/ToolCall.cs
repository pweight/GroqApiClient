using System.Text.Json.Serialization;

namespace GroqApiClient.Models;

/// <summary>
/// Represents a tool call made by the model.
/// </summary>
public class ToolCall
{
    /// <summary>
    /// The ID of the tool call.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// The type of tool call (currently always "function").
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = "function";

    /// <summary>
    /// The function to call.
    /// </summary>
    [JsonPropertyName("function")]
    public FunctionCall Function { get; set; } = new();
}

/// <summary>
/// Represents a function call.
/// </summary>
public class FunctionCall
{
    /// <summary>
    /// The name of the function to call.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The arguments to pass to the function, as a JSON string.
    /// </summary>
    [JsonPropertyName("arguments")]
    public string Arguments { get; set; } = string.Empty;
}
