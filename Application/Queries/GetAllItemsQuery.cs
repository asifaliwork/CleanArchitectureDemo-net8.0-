using Core.Entities;
using Core.Interfaces;
using MediatR;


namespace Application.Queries
{
    public record GetAllItemsQuery() : IRequest<IEnumerable<Item>>;

    public class GetAllItemsQueryHandler(IItemRepository ItemRepository) : IRequestHandler<GetAllItemsQuery , IEnumerable<Item>>
    {
        public  Task<IEnumerable<Item>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            return  ItemRepository.GetAllItems();
        }
    }
}
