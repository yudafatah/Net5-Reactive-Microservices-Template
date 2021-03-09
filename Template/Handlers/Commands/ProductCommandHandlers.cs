using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Template.Cqrs.Commands;

namespace Template.Handlers.Commands
{
    /// <summary>
    /// This class will handle the product commands that are sent to the system
    /// </summary>
    public class ProductCommandHandlers : IRequestHandler<AddProduct, string>,
                                          IRequestHandler<RemoveProduct, string>
    {
        public Task<string> Handle(AddProduct request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> Handle(RemoveProduct request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
