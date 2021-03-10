using System.Threading.Tasks;

namespace Template.Repositories.Interfaces
{
    public interface IInventoryUpdator
    {
        Task Update(int productId, int quantity);
    }
}
