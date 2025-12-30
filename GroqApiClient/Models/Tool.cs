using System.Text.Json.Serialization;

namespace GroqApiClient.Models;

/// <summary>
/// Represents a tool that the model can use.
/// </summary>
public class Tool
{
    /// <summary>
    /// The type of tool (currently always "function").
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = "function";

    /// <summary>
    /// The function definition.
    /// </summary>
    [JsonPropertyName("function")]
    public FunctionDefinition Function { get; set; } = new();
}

/// <summary>
/// Defines a function that can be called by the model.
/// </summary>
public class FunctionDefinition
{
    /// <summary>
    /// The name of the function.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// A description of what the function does.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The parameters the function accepts, as a JSON Schema object.
    /// </summary>
    [JsonPropertyName("parameters")]
    public object? Parameters { get; set; }
}
