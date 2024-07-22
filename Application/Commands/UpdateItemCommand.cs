using Core.Entities;
using Core.Interfaces;
using MediatR;
namespace Application.Commands
{
    public record UpdateItemCommand(int id , MapperEntities Item) : IRequest<MapperEntities>;

    public class UpdateItemCommandHandler(IItemRepository ItemRepository) : IRequestHandler<UpdateItemCommand, MapperEntities>
    {
        public async Task<MapperEntities> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            return await ItemRepository.UpdateItem(request.id, request.Item);
        }
    }

}
