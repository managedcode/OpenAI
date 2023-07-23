using System.Text.Json;

namespace ManagedCode.OpenAI.Chat;

internal class ChatSession : IChatSession
{
    private Queue<IChatSessionRecord> ListRecords { get; } = new();

    public string ToJson()
    {
        return JsonSerializer.Serialize(ListRecords);
    }

    IChatSessionRecord[] IChatSession.Records()
    {
        return ListRecords.ToArray();
    }

    public void AddRecord(IChatSessionRecord record)
    {
        ListRecords.Enqueue(record);
    }

    public void AddRecords(IChatSessionRecord[] records)
    {
        foreach (var record in records)
        {
            AddRecord(record);
        }
    }
}