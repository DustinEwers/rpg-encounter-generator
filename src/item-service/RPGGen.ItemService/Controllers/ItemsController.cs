using Microsoft.AspNetCore.Mvc;
using RPGGen.ItemService.Domain;
using RPGGen.ItemService.Domain.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RPGGen.ItemService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _service;

        public ItemsController(IItemService service)
        {
            _service = service;
        }

        // GET: api/<ItemsController>
        [HttpGet]
        public async Task<IEnumerable<Item>> Get()
        {
            return await _service.GetItems();
        }

        // POST api/<ItemsController>
        [HttpPost]
        public async Task Post([FromBody] Item value)
        {
            await _service.AddItem(value);
        }

        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        public async Task Put(Guid id, [FromBody] Item value)
        {
            await _service.UpdateItem(id, value);
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _service.DeleteItem(id);
        }
    }
}
