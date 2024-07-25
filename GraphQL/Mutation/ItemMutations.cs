using Application.Commands;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL.Mutation
{
    public class ItemMutations
    {
        public async Task<MapperEntities> AddItem([FromBody] MapperEntities item, [Service] ISender sender)
        {
            var result = await sender.Send(new AddItemCommand(item));
            return result;
        }
        public async Task<MapperEntities> UpdateItem([FromRoute] int id, [FromBody] MapperEntities item, [Service] ISender sender)
        {
            var result = await sender.Send(new UpdateItemCommand(id, item));
            return result;
        }
        public async Task<bool> DeleteItem([FromRoute] int id, [Service] ISender sender)
        {
            var result = await sender.Send(new DeleteItemCommand(id));
            return result;
        }
    }
}
