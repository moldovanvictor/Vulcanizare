using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TireHotelsController : ControllerBase
    {
        private readonly WebAPIContext _context;

        public TireHotelsController(WebAPIContext context)
        {
            _context = context;
        }

        // GET: api/TireHotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TireHotel>>> GetTireHotel()
        {
          if (_context.TireHotel == null)
          {
              return NotFound();
          }
            return await _context.TireHotel.ToListAsync();
        }

        // GET: api/TireHotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TireHotel>> GetTireHotel(int id)
        {
          if (_context.TireHotel == null)
          {
              return NotFound();
          }
            var tireHotel = await _context.TireHotel.FindAsync(id);

            if (tireHotel == null)
            {
                return NotFound();
            }

            return tireHotel;
        }

        // PUT: api/TireHotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTireHotel(int id, TireHotel tireHotel)
        {
            if (id != tireHotel.Id)
            {
                return BadRequest();
            }

            _context.Entry(tireHotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TireHotelExists(id))
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

        // POST: api/TireHotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TireHotel>> PostTireHotel(TireHotel tireHotel)
        {
          if (_context.TireHotel == null)
          {
              return Problem("Entity set 'WebAPIContext.TireHotel'  is null.");
          }
            _context.TireHotel.Add(tireHotel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTireHotel", new { id = tireHotel.Id }, tireHotel);
        }

        // DELETE: api/TireHotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTireHotel(int id)
        {
            if (_context.TireHotel == null)
            {
                return NotFound();
            }
            var tireHotel = await _context.TireHotel.FindAsync(id);
            if (tireHotel == null)
            {
                return NotFound();
            }

            _context.TireHotel.Remove(tireHotel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TireHotelExists(int id)
        {
            return (_context.TireHotel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
