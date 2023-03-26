
namespace ManagedCode.OpenAI.Chat
{
    public interface IChatSessionLoader
    {
        IChatSession FromJson(string json);
    }
}
