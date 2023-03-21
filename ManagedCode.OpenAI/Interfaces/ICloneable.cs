namespace ManagedCode.OpenAI.Interfaces;

public interface ICloneable<T>: ICloneable
{
    public T Clone();

    object ICloneable.Clone() => Clone();
}