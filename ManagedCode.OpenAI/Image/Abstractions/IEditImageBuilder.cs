namespace ManagedCode.OpenAI.Image
{
    public interface IEditImageBuilder: IBaseImageBuilder<IEditImageBuilder>
    {
        public IEditImageBuilder SetImageMask(string base64);

        public Task<IGptImage<string>> EditAsync();

        public Task<IGptImage<string[]>> EditMultipleAsync(int count);
    }
}
