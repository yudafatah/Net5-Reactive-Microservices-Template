using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Template.Dtos;
using Template.Repositories.Interfaces;
using static Template.Cqrs.Queries.ProductQuery;

namespace Template.Handlers.Queries
{
    public class ProductQueryHandler : IRequestHandler<GetProduct, ProductDto[]>
    {
        private readonly IProductProvider productProvider;

        public ProductQueryHandler(IProductProvider productProvider)
        {
            this.productProvider = productProvider;
        }
        public Task<ProductDto[]> Handle(GetProduct request, CancellationToken cancellationToken)
        {
            return Task.FromResult(productProvider.Get());
        }
    }
}
