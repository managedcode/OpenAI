namespace ManagedCode.OpenAI.Interfaces;

public interface IDeepCloneable<T>
{
    T DeepClone();
}