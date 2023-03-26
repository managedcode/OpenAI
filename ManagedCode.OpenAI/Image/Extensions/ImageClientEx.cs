﻿using ManagedCode.OpenAI.Client;
using ManagedCode.OpenAI.Image.Builders;

namespace ManagedCode.OpenAI.Image.Extensions
{
    public static class ImageClientEx
    {
        public static IEditImageBuilder EditImage(this IGptClient client, 
            string instruction, Func<IImageLoader, string> image)
        {
            var loader = new DefaultImageLoader();
            return client.EditImage(instruction, image.Invoke(loader));
        }

        public static IVariationImageBuilder VariationImage(this IGptClient client,
            Func<IImageLoader, string> image)
        {
            var loader = new DefaultImageLoader();
            return client.VariationImage(image.Invoke(loader));
        }
    }
}