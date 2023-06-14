using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ModelClassLib;
using RestService.Repositories;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestService.Controllers
{
    //ALL swagger methods working as should
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemRepository _repository;
        public ItemsController(ItemRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<ItemsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<Item>> Get()
        {
            List<Item> Items = _repository.GetAll();
            if (Items == null) return NotFound("No items exist");
            return Ok(Items);
        }

        // GET api/<ItemsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Item> Get(int id)
        {
            Item Item = _repository.GetById(id);
            if (Item == null) return NotFound("No such id" + id);
            return Ok(Item);
        }

        // POST api/<ItemsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Item> Post([FromBody] Item value)
        {
            try
            {
                Item createdItem = _repository.Add(value);
                return Created($"api/ItemsController/{createdItem.Id}", createdItem);
            }
            catch (ArgumentException n)
            {
                return BadRequest(n.Message);
            }
        }
        // PUT api/<ItemsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpPut]
        public ActionResult<Item> Put([FromBody] Item value)
        {
            try
            {
                Item updatedItem = _repository.Update(value);
                return Ok(updatedItem);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public ActionResult<Item> Delete(int id)
        {
            Item deletedPellet = _repository.Delete(id);
            if (deletedPellet == null) return NotFound("No items deleted, id does not exist. Id:" + id);
            return Ok(deletedPellet);
        }
    }
}