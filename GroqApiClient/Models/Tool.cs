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
    /// This should be a dictionary representing a JSON Schema with properties like "type", "properties", and "required".
    /// Example: new Dictionary&lt;string, object&gt; { ["type"] = "object", ["properties"] = new Dictionary&lt;string, object&gt; { ... } }
    /// </summary>
    [JsonPropertyName("parameters")]
    public Dictionary<string, object>? Parameters { get; set; }
}
