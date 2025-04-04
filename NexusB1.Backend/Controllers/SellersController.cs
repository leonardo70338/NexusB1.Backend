using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NexusB1.Backend.Data;
using NexusB1.Backend.Models;

namespace NexusB1.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SellersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/sellers
        [HttpGet]
        public IActionResult Get()
        {
            var sellers = _context.Sellers.ToList();
            return Ok(sellers);
        }

        // GET: api/sellers/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var seller = _context.Sellers.Find(id);
            if (seller == null)
                return NotFound();

            return Ok(seller);
        }

        // GET: api/sellers/slpcode/{slpcode}
        [HttpGet("slpcode/{slpcode}")]
        public IActionResult GetBySlpCode(string slpcode)
        {
            // Busca el vendedor por su correo electrónico
            var seller = _context.Sellers.FirstOrDefault(s => s.SlpCode == slpcode);

            if (seller == null)
                return NotFound("No se encontró ningún vendedor con el código SAP proporcionado.");

            return Ok(seller);
        }

        // POST: api/sellers
        [HttpPost]
        public IActionResult Post([FromBody] Seller seller)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _context.Sellers.Add(seller);
                _context.SaveChanges();

                return Created($"/api/sellers/{seller.SellerId}", seller);
            }
            catch (Exception ex)
            {
                // Manejo de errores específicos, como violación de índice único
                if (ex.InnerException?.Message.Contains("IX_Sellers_Email") == true)
                {
                    return Conflict("El correo electrónico ya está registrado.");
                }
                if (ex.InnerException?.Message.Contains("IX_Sellers_SlpCode") == true)
                {
                    return Conflict("El código de vendedor que proviene de SAP ya está registrado.");
                }

                return StatusCode(500, "Ocurrió un error al procesar la solicitud.");
            }
        }

        // PUT: api/sellers/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Seller updatedSeller)
        {
            try
            {
                var seller = _context.Sellers.Find(id);
                if (seller == null)
                    return NotFound();

                seller.Name = updatedSeller.Name;
                seller.Email = updatedSeller.Email;
                seller.Phone = updatedSeller.Phone;
                seller.CommissionPercentage = updatedSeller.CommissionPercentage;
                seller.IsActive = updatedSeller.IsActive;

                _context.SaveChanges();
                return Ok(seller);
            }
            catch (Exception ex)
            {
                // Manejo de errores específicos, como violación de índice único
                if (ex.InnerException?.Message.Contains("IX_Sellers_Email") == true)
                {
                    return Conflict("El correo electrónico ya está registrado.");
                }

                return StatusCode(500, "Ocurrió un error al procesar la solicitud.");
            }
        }

        // DELETE: api/sellers/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var seller = _context.Sellers.Find(id);
            if (seller == null)
                return NotFound();

            _context.Sellers.Remove(seller);
            _context.SaveChanges();

            return Ok();
        }
    }
}
