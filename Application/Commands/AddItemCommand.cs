using Application.Mapper;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using MediatR;


namespace Application.Commands
{
    public record AddItemCommand(MapperEntities Item ) : IRequest< MapperEntities>;
    
    public class AddItemCommandHandler(IItemRepository _itemRepository) : IRequestHandler<AddItemCommand, MapperEntities>
    {
       
        public async Task<MapperEntities> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            return await _itemRepository.AddItem(request.Item);
        }
    }


}
