namespace GroqApiClient.Client;

public interface IGroqClient
{
    Task<HttpResponseMessage> ChatCompletions(string query);
}