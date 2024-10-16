using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelUp.Data;
using TravelUp.Models;

namespace TravelUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsApiController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemsApiController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        // GET: api/items
        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            var items = _itemRepository.GetAllItems();
            return Ok(items);
        }

        // GET: api/items/{id}
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(int id)
        {
            var item = _itemRepository.GetItemById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST: api/items
        [HttpPost]
        public ActionResult<Item> AddItem([FromBody] Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _itemRepository.AddItem(item);
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        // PUT: api/items/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, [FromBody] Item item)
        {
            if (id != item.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var existingItem = _itemRepository.GetItemById(id);
            if (existingItem == null)
            {
                return NotFound();
            }

            _itemRepository.UpdateItem(item);
            return NoContent(); // 204 No Content, since the update was successful.
        }

        // DELETE: api/items/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var item = _itemRepository.GetItemById(id);
            if (item == null)
            {
                return NotFound();
            }

            _itemRepository.DeleteItem(id);
            return NoContent(); // 204 No Content, since the deletion was successful.
        }
    }
}
