using Application.Commands;
using Application.Queries;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController(ISender sender) : ControllerBase
    {

        [HttpPost("AddItem")]
        public async Task<ActionResult> AddItem([FromBody] MapperEntities item) 
        {
            var result = sender.Send(new AddItemCommand(item));
            return Ok(result);
        }
        [HttpGet("GetAllItems")]
        public async Task<ActionResult> GetAllItems()
        {
            var result = await sender.Send(new GetAllItemsQuery());
            return Ok(result);
        }
        [HttpGet("GetItemById/{id}")]
        public ActionResult GetItemById([FromRoute] int id)
        {
            var result = sender.Send(new GetItemByIdQuery(id));
            return Ok(result);
        }
        [HttpPut("UpdateItem/{id}")]
        public async Task<ActionResult> UpdateItem( [FromRoute] int id ,[FromBody] MapperEntities item)
        {
            var result = sender.Send(new UpdateItemCommand(id,item));
            return Ok(result);
        }
        [HttpDelete("DeleteItem/{id}")]
        public async Task<ActionResult> DeleteItem([FromRoute] int id)
        {
            var result = sender.Send(new DeleteItemCommand(id));
            return Ok(result);
        }
    }
}
