using System.Text.Json.Serialization;

namespace GroqApiClient.Models;

/// <summary>
/// Error response from the Groq API.
/// </summary>
public class ErrorResponse
{
    /// <summary>
    /// Error details.
    /// </summary>
    [JsonPropertyName("error")]
    public ErrorDetail Error { get; set; } = new();
}

/// <summary>
/// Details about an error.
/// </summary>
public class ErrorDetail
{
    /// <summary>
    /// Error message.
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Error type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Error code.
    /// </summary>
    [JsonPropertyName("code")]
    public string? Code { get; set; }
}
