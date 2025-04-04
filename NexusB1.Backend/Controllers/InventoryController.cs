using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NexusB1.Backend.Data;
using NexusB1.Backend.Models;

namespace NexusB1.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InventoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/inventory
        [HttpGet]
        public IActionResult Get()
        {
            var inventoryItems = _context.InventoryItems.ToList();
            return Ok(inventoryItems);
        }

        // POST: api/inventory
        [HttpPost]
        public IActionResult Post([FromBody] InventoryItem item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.InventoryItems.Add(item);
            _context.SaveChanges();

            return Created($"/api/inventory/{item.Id}", item);
        }

        // PUT: api/inventory/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] InventoryItem updatedItem)
        {
            var item = _context.InventoryItems.Find(id);
            if (item == null)
                return NotFound();

            item.Name = updatedItem.Name;
            item.Quantity = updatedItem.Quantity;

            _context.SaveChanges();
            return Ok(item);
        }

        // DELETE: api/inventory/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.InventoryItems.Find(id);
            if (item == null)
                return NotFound();

            _context.InventoryItems.Remove(item);
            _context.SaveChanges();

            return Ok();
        }
    }
}
