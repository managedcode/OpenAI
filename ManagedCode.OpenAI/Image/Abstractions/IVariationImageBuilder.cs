namespace ManagedCode.OpenAI.Image
{
    public interface IVariationImageBuilder: IBaseImageBuilder<IVariationImageBuilder>
    {
        public Task<IGptImage<string>> ExecuteAsync();

        public Task<IGptImage<string[]>> ExecuteMultipleAsync(int count);
    }
}
