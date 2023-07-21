using Azure.AI.OpenAI;
using ManagedCode.OpenAI.Chat;
using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.Azure.Chat;

internal static class AzureOpenAiChatExtensions
{
    public static async Task<IAnswer<IChatMessage>> AskAsync(this IOpenAiChat chat, string message, ChatRole role)
    {
        return await chat.AskAsync(message, new ChatMessageParameters() { Role = role.ToString() });
    }
}