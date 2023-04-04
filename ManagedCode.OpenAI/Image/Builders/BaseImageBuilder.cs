using ManagedCode.OpenAI.API.Image;
using ManagedCode.OpenAI.Extensions;

namespace ManagedCode.OpenAI.Image
{
    internal abstract class BaseImageBuilder<TBuilder, TRequest> : IBaseImageBuilder<TBuilder>
        where TRequest : BaseImageRequestDto, new()
        where TBuilder : IBaseImageBuilder<TBuilder>
    {
        protected BaseImageBuilder()
        {
            Request = new TRequest();
        }

        protected TRequest Request { get; }

        public TBuilder SetImageResolution(string resolution)
        {
            Request.Size = resolution;
            return Builder();
        }

        public TBuilder SetImageResolution(ImageResolution resolution)
        {
            Request.Size = resolution.Name();
            return Builder();
        }

        public TBuilder AsBase64String()
        {
            Request.ResponseFormat = ImageFormat.Base64Json.Name();
            return Builder();
        }

        public TBuilder AsUrl()
        {
            Request.ResponseFormat = ImageFormat.Url.Name();
            return Builder();
        }

        public TBuilder SetUser(string user)
        {
            Request.User = user;
            return Builder();
        }

        protected abstract TBuilder Builder();

    }
}
