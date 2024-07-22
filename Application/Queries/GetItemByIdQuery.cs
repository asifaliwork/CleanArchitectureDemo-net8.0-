using Core.Entities;
using Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public record GetItemByIdQuery(int id) :IRequest<Item>;

    public class GetItemByIdQueryHandler(IItemRepository ItemRepository) : IRequestHandler<GetItemByIdQuery, Item>
    {
        public async Task<Item> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            return  ItemRepository.GetItemById(request.id);
        }
    }


}
