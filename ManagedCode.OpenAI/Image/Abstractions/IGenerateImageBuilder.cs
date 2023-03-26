namespace ManagedCode.OpenAI.Image
{
    public interface IGenerateImageBuilder: IBaseImageBuilder<IGenerateImageBuilder>
    {
        public Task<IGptImage<string>> GenerateAsync();

        public Task<IGptImage<string[]>> GenerateMultipleAsync(int count);
    }
}
