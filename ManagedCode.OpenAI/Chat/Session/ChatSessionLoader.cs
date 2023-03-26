using System.Text.Json;

namespace ManagedCode.OpenAI.Chat
{
    public class ChatSessionLoader : IChatSessionLoader
    {
        public IChatSession FromJson(string json)
        {
            var records = JsonSerializer.Deserialize<ChatSessionRecord[]>(json)
                          ?? throw new ArgumentException($"Wrong session format: {json}");

            var session = new ChatSession();
            session.AddRecords(records.Cast<IChatSessionRecord>().ToArray());
            return session;
        }
    }
}
