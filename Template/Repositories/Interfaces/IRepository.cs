using System.Collections.Generic;
using System.Threading.Tasks;

namespace Template.Repositories.Interfaces
{
    public interface IRepository<T,K>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<string> Create(K item);
        Task<string> Update(K item);
        Task<string> Delete(int id);
    }
}
