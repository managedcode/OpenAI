namespace ManagedCode.OpenAI.Image;

public interface IGenerateImageBuilder : IBaseImageBuilder<IGenerateImageBuilder>
{
    public Task<IGptImage<string>> ExecuteAsync();

    public Task<IGptImage<string[]>> ExecuteMultipleAsync(int count);
}