namespace ManagedCode.OpenAI.Image;

public interface IBaseImageBuilder<out TBuilder>
{
    public TBuilder SetImageResolution(string resolution);
    public TBuilder SetImageResolution(ImageResolution resolution);

    public TBuilder AsBase64String();

    public TBuilder AsUrl();

    public TBuilder SetUser(string user);
}