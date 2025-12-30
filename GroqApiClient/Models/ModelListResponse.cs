using System.Text.Json.Serialization;

namespace GroqApiClient.Models;

/// <summary>
/// Response containing a list of available models.
/// </summary>
public class ModelListResponse
{
    /// <summary>
    /// Object type (always "list").
    /// </summary>
    [JsonPropertyName("object")]
    public string Object { get; set; } = string.Empty;

    /// <summary>
    /// List of available models.
    /// </summary>
    [JsonPropertyName("data")]
    public List<Model> Data { get; set; } = new();
}

/// <summary>
/// Information about a model.
/// </summary>
public class Model
{
    /// <summary>
    /// Unique identifier for the model.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Object type (always "model").
    /// </summary>
    [JsonPropertyName("object")]
    public string Object { get; set; } = string.Empty;

    /// <summary>
    /// Unix timestamp of when the model was created.
    /// </summary>
    [JsonPropertyName("created")]
    public long Created { get; set; }

    /// <summary>
    /// The organization that owns the model.
    /// </summary>
    [JsonPropertyName("owned_by")]
    public string OwnedBy { get; set; } = string.Empty;

    /// <summary>
    /// Whether the model is active.
    /// </summary>
    [JsonPropertyName("active")]
    public bool Active { get; set; }

    /// <summary>
    /// Maximum context length for the model.
    /// </summary>
    [JsonPropertyName("context_window")]
    public int? ContextWindow { get; set; }
}
