using Application.Queries;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL.Query
{
    public class Query
    {
        public Task<IEnumerable<Item>> GetAllItems([Service] ISender sender)
        {
            return sender.Send(new GetAllItemsQuery());
        }
        public Task<Item> GetItemById([FromRoute] int id, [Service] ISender sender)
        {
            return sender.Send(new GetItemByIdQuery(id));
        }


    }
}
