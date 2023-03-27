using System.Text.Json.Serialization;

public interface IDataArrayResponseDto<out TModel>
{
    public TModel[] Data { get; }
    public string Object { get; }
}