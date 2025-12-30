# GroqApiClient

A .NET client library for the Groq AI API, providing a simple and efficient way to interact with Groq's ultra-fast LLM inference endpoints.

## Features

- 🚀 **High-Performance**: Built for Groq's lightning-fast LPU inference
- 💬 **Chat Completions**: Full support for chat-based interactions
- 📡 **Streaming**: Real-time token streaming for responsive applications
- 🛠️ **Tool/Function Calling**: Support for advanced function calling capabilities
- 📋 **Model Management**: List and query available models
- ⚡ **Async/Await**: Fully asynchronous API
- 📝 **Strongly Typed**: Complete type safety with detailed models
- 🔒 **Error Handling**: Comprehensive error handling with detailed messages

## Installation

```bash
dotnet add package GroqApiClient
```

Or via NuGet Package Manager:

```
Install-Package GroqApiClient
```

## Quick Start

### Prerequisites

Get your API key from [Groq Console](https://console.groq.com/) and set it as an environment variable:

```bash
export GROQ_API_KEY="your-api-key-here"
```

### Basic Usage

```csharp
using GroqApiClient.Client;
using GroqApiClient.Models;

// Create a client (uses GROQ_API_KEY environment variable)
var client = new GroqClient();

// Or provide the API key directly
// var client = new GroqClient("your-api-key-here");

// Create a simple chat completion request
var request = new ChatCompletionRequest
{
    Model = "llama3-8b-8192",
    Messages = new List<ChatMessage>
    {
        new ChatMessage
        {
            Role = "user",
            Content = "Explain quantum computing in simple terms"
        }
    }
};

// Get the completion
var response = await client.CreateChatCompletionAsync(request);
Console.WriteLine(response.Choices[0].Message.Content);
```

### Streaming Responses

```csharp
var request = new ChatCompletionRequest
{
    Model = "llama3-8b-8192",
    Messages = new List<ChatMessage>
    {
        new ChatMessage
        {
            Role = "user",
            Content = "Write a short story about a robot"
        }
    }
};

// Stream the response
await foreach (var chunk in client.CreateChatCompletionStreamAsync(request))
{
    var content = chunk.Choices[0]?.Delta?.Content;
    if (!string.IsNullOrEmpty(content))
    {
        Console.Write(content);
    }
}
```

### Advanced Options

```csharp
var request = new ChatCompletionRequest
{
    Model = "mixtral-8x7b-32768",
    Messages = new List<ChatMessage>
    {
        new ChatMessage { Role = "system", Content = "You are a helpful assistant." },
        new ChatMessage { Role = "user", Content = "Hello!" }
    },
    Temperature = 0.7,
    MaxTokens = 1000,
    TopP = 0.9,
    FrequencyPenalty = 0.5,
    PresencePenalty = 0.5
};

var response = await client.CreateChatCompletionAsync(request);
```

### List Available Models

```csharp
var models = await client.ListModelsAsync();

foreach (var model in models.Data)
{
    Console.WriteLine($"Model: {model.Id}");
    Console.WriteLine($"  Context Window: {model.ContextWindow}");
    Console.WriteLine($"  Owner: {model.OwnedBy}");
}
```

### Function Calling

```csharp
var request = new ChatCompletionRequest
{
    Model = "llama3-70b-8192",
    Messages = new List<ChatMessage>
    {
        new ChatMessage
        {
            Role = "user",
            Content = "What's the weather in San Francisco?"
        }
    },
    Tools = new List<Tool>
    {
        new Tool
        {
            Type = "function",
            Function = new FunctionDefinition
            {
                Name = "get_weather",
                Description = "Get the current weather in a location",
                Parameters = new
                {
                    type = "object",
                    properties = new
                    {
                        location = new
                        {
                            type = "string",
                            description = "The city and state, e.g. San Francisco, CA"
                        }
                    },
                    required = new[] { "location" }
                }
            }
        }
    }
};

var response = await client.CreateChatCompletionAsync(request);
```

## Available Models

Some popular models available on Groq:
- `llama3-8b-8192` - Fast and efficient
- `llama3-70b-8192` - More capable, balanced
- `mixtral-8x7b-32768` - Large context window
- `gemma-7b-it` - Google's Gemma model

Use `ListModelsAsync()` to get the complete, up-to-date list.

## Error Handling

```csharp
try
{
    var response = await client.CreateChatCompletionAsync(request);
}
catch (HttpRequestException ex)
{
    Console.WriteLine($"API Error: {ex.Message}");
}
catch (ArgumentNullException ex)
{
    Console.WriteLine($"Invalid request: {ex.Message}");
}
```

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## Links

- [Groq Documentation](https://console.groq.com/docs)
- [Groq Console](https://console.groq.com/)
- [GitHub Repository](https://github.com/pweight/GroqApiClient)

