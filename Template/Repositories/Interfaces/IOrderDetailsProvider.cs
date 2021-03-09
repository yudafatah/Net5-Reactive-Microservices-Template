using System.Threading.Tasks;
using Template.Dtos;

namespace Template.Repositories.Interfaces
{
    public interface IOrderDetailsProvider
    {
        Task<string> CancelOrder(int id, string reason, int cencelledBy);
    }
}
