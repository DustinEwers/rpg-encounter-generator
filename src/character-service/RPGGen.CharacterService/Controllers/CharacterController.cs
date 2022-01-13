using Microsoft.AspNetCore.Mvc;
using RPGGen.CharacterService.Domain;
using RPGGen.CharacterService.Domain.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RPGGen.CharacterService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _service;

        public CharacterController(ICharacterService service)
        {
            _service = service;
        }

        // GET: api/<CharacterController>
        [HttpGet]
        public async Task<IEnumerable<Character>> Get()
        {
            return await _service.GetCharacters();
        }

        // POST api/<CharacterController>
        [HttpPost]
        public async Task Post([FromBody] Character value)
        {
            await _service.AddCharacter(value);
        }

        // PUT api/<CharacterController>/5
        [HttpPut("{id}")]
        public async Task Put(Guid id, [FromBody] Character value)
        {
            await _service.UpdateCharacter(id, value);
        }

        // DELETE api/<CharacterController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _service.DeleteCharacter(id);
        }
    }
}
