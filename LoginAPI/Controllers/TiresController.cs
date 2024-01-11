using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoginAPI.Data;
using LoginAPI.Models;

namespace LoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiresController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public TiresController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Tires
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tire>>> GetTire()
        {
          if (_context.Tire == null)
          {
              return NotFound();
          }
            return await _context.Tire.ToListAsync();
        }

        // GET: api/Tires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tire>> GetTire(int id)
        {
          if (_context.Tire == null)
          {
              return NotFound();
          }
            var tire = await _context.Tire.FindAsync(id);

            if (tire == null)
            {
                return NotFound();
            }

            return tire;
        }

        // PUT: api/Tires/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateTire/{id}")]
        public async Task<IActionResult> PutTire(int id, Tire tire)
        {
            if (id != tire.Id)
            {
                return BadRequest();
            }

            _context.Entry(tire).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TireExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tires
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("AddTire")]
        public async Task<ActionResult<Tire>> PostTire(Tire tire)
        {
          if (_context.Tire == null)
          {
              return Problem("Entity set 'ApplicationDBContext.Tire'  is null.");
          }
            _context.Tire.Add(tire);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTire", new { id = tire.Id }, tire);
        }

        // DELETE: api/Tires/5
        [HttpDelete("DeleteTire/{id}")]
        public async Task<IActionResult> DeleteTire(int id)
        {
            if (_context.Tire == null)
            {
                return NotFound();
            }
            var tire = await _context.Tire.FindAsync(id);
            if (tire == null)
            {
                return NotFound();
            }

            _context.Tire.Remove(tire);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TireExists(int id)
        {
            return (_context.Tire?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
