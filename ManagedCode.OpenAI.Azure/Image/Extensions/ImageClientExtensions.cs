﻿namespace ManagedCode.OpenAI.Image;

public static class ImageClientExtensions
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

    public static IEditImageBuilder SetImageMask(this IEditImageBuilder builder,
        Func<IImageLoader, string> image)
    {
        var loader = new DefaultImageLoader();
        builder.SetImageMask(image.Invoke(loader));
        return builder;
    }
}