using ManagedCode.OpenAI.API;
using ManagedCode.OpenAI.Chat.Extensions;

namespace ManagedCode.OpenAI.Client.Extensions
{
    internal static class MapperClientEx
    {
        public static IModel ToModel(this ModelDto dto)
        {
            return new Model()
            {
                Id = dto.Id,
                OwnedBy = dto.OwnedBy,
                Permission = dto.Permission.Select(x => x.ToPermission()).ToArray(),
            };
        }

    }
}
