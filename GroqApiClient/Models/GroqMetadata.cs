using System.Text.Json.Serialization;

namespace GroqApiClient.Models;

/// <summary>
/// Groq-specific metadata about request processing.
/// </summary>
public class GroqMetadata
{
    /// <summary>
    /// Unique identifier for this request.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }
}
