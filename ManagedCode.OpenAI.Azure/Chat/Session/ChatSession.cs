using System.Text.Json;

namespace ManagedCode.OpenAI.Chat;

internal class ChatSession : IChatSession
{
    public List<IChatSessionRecord> ListRecords { get; } = new();

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
        ListRecords.Add(record);
    }

    public void AddRecords(IChatSessionRecord[] records)
    {
        ListRecords.AddRange(records);
    }
}