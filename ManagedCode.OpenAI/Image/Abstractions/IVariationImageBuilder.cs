namespace ManagedCode.OpenAI.Image
{
    public interface IVariationImageBuilder: IBaseImageBuilder<IVariationImageBuilder>
    {
       
        public Task<IGptImage<string>> VariationAsync();

        public Task<IGptImage<string[]>> VariationsMultipleAsync(int count);
    }
}
