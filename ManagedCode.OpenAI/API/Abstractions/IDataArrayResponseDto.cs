using System.Text.Json.Serialization;

internal interface IDataArrayResponseDto<out TModel>
{
    public TModel[] Data { get; }
    public string Object { get; }
}