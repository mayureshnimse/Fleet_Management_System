using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FleetManagement.Model;

namespace FleetManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarTypeMastersController : ControllerBase
    {
        private readonly FleetContext _context;

        public CarTypeMastersController(FleetContext context)
        {
            _context = context;
        }

        // GET: api/CarTypeMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarTypeMaster>>> GetCarTypeMaster()
        {
          if (_context.CarTypeMaster == null)
          {
              return NotFound();
          }
            return await _context.CarTypeMaster.ToListAsync();
        }

        // GET: api/CarTypeMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarTypeMaster>> GetCarTypeMaster(int? id)
        {
          if (_context.CarTypeMaster == null)
          {
              return NotFound();
          }
            var carTypeMaster = await _context.CarTypeMaster.FindAsync(id);

            if (carTypeMaster == null)
            {
                return NotFound();
            }

            return carTypeMaster;
        }

        // PUT: api/CarTypeMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarTypeMaster(int? id, CarTypeMaster carTypeMaster)
        {
            if (id != carTypeMaster.CarTypeId)
            {
                return BadRequest();
            }

            _context.Entry(carTypeMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarTypeMasterExists(id))
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

        // POST: api/CarTypeMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarTypeMaster>> PostCarTypeMaster(CarTypeMaster carTypeMaster)
        {
          if (_context.CarTypeMaster == null)
          {
              return Problem("Entity set 'FleetContext.CarTypeMaster'  is null.");
          }
            _context.CarTypeMaster.Add(carTypeMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarTypeMaster", new { id = carTypeMaster.CarTypeId }, carTypeMaster);
        }

        // DELETE: api/CarTypeMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarTypeMaster(int? id)
        {
            if (_context.CarTypeMaster == null)
            {
                return NotFound();
            }
            var carTypeMaster = await _context.CarTypeMaster.FindAsync(id);
            if (carTypeMaster == null)
            {
                return NotFound();
            }

            _context.CarTypeMaster.Remove(carTypeMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarTypeMasterExists(int? id)
        {
            return (_context.CarTypeMaster?.Any(e => e.CarTypeId == id)).GetValueOrDefault();
        }
    }
}
