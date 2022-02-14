using Dapr;
using Microsoft.AspNetCore.Mvc;
using RPGGen.CharacterService.Domain;
using RPGGen.CharacterService.Domain.Services;

namespace RPGGen.CharacterService.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _service;

        public ItemController(IItemService service) => _service = service;        

        [Topic("dnd-app-pubsub", "item-update")]
        [HttpPost("/item-update")]
        public async Task<IActionResult> ItemChanged([FromBody] Item item)
        {
            await _service.UpdateItem(item);
            return Ok();
        }
    }
}
