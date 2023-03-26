namespace ManagedCode.OpenAI.Exceptions
{
    public class OpenAICountOutOfRangeException: Exception
    {
        public OpenAICountOutOfRangeException()
        : base("'Count' must be in range [0;10]")
        {

        }
    }
}
