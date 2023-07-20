using ManagedCode.OpenAI.API;
using ManagedCode.OpenAI.Chat;

namespace ManagedCode.OpenAI.Client;

internal static class MapperClientExtensions
{
    public static IModel ToModel(this ModelDto dto)
    {
        return new Model
        {
            Id = dto.Id,
            OwnedBy = dto.OwnedBy,
            Permission = dto.Permission.Select(x => x.ToPermission()).ToArray()
        };
    }
}