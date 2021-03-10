using Template.Dtos;

namespace Template.Repositories.Interfaces
{
    public interface IProductProvider
    {
        ProductDto[] Get();
    }
}
