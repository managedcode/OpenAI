namespace ManagedCode.OpenAI.Image
{
    internal class DefaultImageLoader : IImageLoader
    {
        public string FromBytes(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        public string FromBase64(string base64)
        {
            return base64;
        }
    }
}
