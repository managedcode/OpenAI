namespace ManagedCode.OpenAI.Image
{
    public static class ImageClientEx
    {
        public static IEditImageBuilder EditImage(this IImageClient client, 
            string instruction, Func<IImageLoader, string> image)
        {
            var loader = new DefaultImageLoader();
            return client.EditImage(instruction, image.Invoke(loader));
        }

        public static IVariationImageBuilder VariationImage(this IImageClient client,
            Func<IImageLoader, string> image)
        {
            var loader = new DefaultImageLoader();
            return client.VariationImage(image.Invoke(loader));
        }
    }
}
