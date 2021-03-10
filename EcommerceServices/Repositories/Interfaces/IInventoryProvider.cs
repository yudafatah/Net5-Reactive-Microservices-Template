using Template.Dtos;

namespace Template.Repositories.Interfaces
{
    public interface IInventoryProvider
    {
        InventoryDto[] Get();
    }
}
