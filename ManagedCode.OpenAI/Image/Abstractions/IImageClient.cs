namespace ManagedCode.OpenAI.Image
{
    public interface IImageClient
    {
        public IGenerateImageBuilder GenerateImage(string description);

        public IEditImageBuilder EditImage(string description, string imageBase64);

        public IVariationImageBuilder VariationImage(string imageBase64);

    }
}
