namespace ManagedCode.OpenAI.Image
{
    public interface IImageLoader
    {
        public string FromBytes(byte[] bytes);

        public string FromBase64(string base64);
    }
}
