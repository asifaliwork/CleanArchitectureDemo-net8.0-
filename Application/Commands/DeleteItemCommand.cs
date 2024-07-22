using Core.Interfaces;
using MediatR;

namespace Application.Commands
{
    public record DeleteItemCommand(int id ) : IRequest<bool>;

    public class DeleteItemCommandHandler(IItemRepository ItemRepository) : IRequestHandler<DeleteItemCommand ,bool>
    {
        public Task<bool> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            return  ItemRepository.DeleteItem(request.id);
        }
    }

}
