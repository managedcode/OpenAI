namespace ManagedCode.OpenAI.Image
{
    public interface IEditImageBuilder: IBaseImageBuilder<IEditImageBuilder>
    {
        public IEditImageBuilder SetImageMask(string base64);

        public Task<IGptImage<string>> ExecuteAsync();

        public Task<IGptImage<string[]>> ExecuteMultipleAsync(int count);
    }
}
