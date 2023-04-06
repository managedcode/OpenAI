namespace ManagedCode.OpenAI.Chat;

public interface IChatSession
{
    public string ToJson();

    public IChatSessionRecord[] Records();

    public void AddRecord(IChatSessionRecord record);

    public void AddRecords(IChatSessionRecord[] records);
}