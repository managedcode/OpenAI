using FluentAssertions;
using ManagedCode.OpenAI.Image;
using ManagedCode.OpenAI.Tests.Attributes;
using ManagedCode.OpenAI.Tests.Base;
using ManagedCode.OpenAI.Tests.Properties;
using Microsoft.Extensions.Configuration;
using Xunit.Abstractions;

namespace ManagedCode.OpenAI.Tests;

public class ImageTests: BaseTestClass
{
    public ImageTests(ITestOutputHelper output, IConfiguration configuration) 
        : base(output, configuration)
    {
    }


    [ManualTest]
    public async Task GenerateImage_Success()
    {
        var client = ClientBuilder.Build();
        var image = await client.ImageClient.GenerateImage("Red dragon")
            .SetImageResolution(ImageResolution._512x512).ExecuteAsync();

        Log($"Image url: {image.Content}");
        image.Content.Should().NotBeNullOrWhiteSpace();
    }

    [ManualTest]
    public async Task GenerateImageMultiple_Success()
    {
        var client = ClientBuilder.Build();
        var result = await client.ImageClient
            .GenerateImage("Red dragon")
            .SetImageResolution(ImageResolution._512x512)
            .ExecuteMultipleAsync(2);

        result.Content.Should().HaveCount(2);
        foreach (var image in result.Content)
        {
            Log($"Image url: {image}");
            image.Should().NotBeNullOrWhiteSpace();
        }
    }


    [ManualTest]
    public async Task EditImage_Success()
    {
        var client = ClientBuilder.Build();
        var edited = await client
            .ImageClient.EditImage("change color to blue",
                x => x.FromBytes(Resources.Dog))
        .AsUrl()
        .ExecuteAsync();

        Log($"Edited image url: {edited.Content}");
        edited.Content.Should().NotBeNullOrWhiteSpace();
    }

    [ManualTest]
    public async Task EditImageMultiple_Success()
    {
        var client = ClientBuilder.Build();
        var edited = await client
            .ImageClient.EditImage("change color to blue",
                x => x.FromBytes(Resources.Dog))
            .AsUrl()
            .ExecuteMultipleAsync(2);

        edited.Content.Should().HaveCount(2);
        foreach (var image in edited.Content)
        {
            Log($"Edited image url: {image}");
            image.Should().NotBeNullOrWhiteSpace();
        }
    }
}