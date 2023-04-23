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
    public class CarMastersController : ControllerBase
    {
        private readonly FleetContext _context;

        public CarMastersController(FleetContext context)
        {
            _context = context;
        }

        // GET: api/CarMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarMaster>>> GetCarMaster()
        {
          

            if (_context.CarMaster == null)
          {
              return NotFound();
          }
            return await _context.CarMaster.ToListAsync();
        }

        // GET: api/CarMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarMaster>> GetCarMaster(int? id)
        {
          if (_context.CarMaster == null)
          {
              return NotFound();
          }
            var carMaster = await _context.CarMaster.FindAsync(id);

            if (carMaster == null)
            {
                return NotFound();
            }

            return carMaster;
        }

        // PUT: api/CarMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarMaster(int? id, CarMaster carMaster)
        {
            if (id != carMaster.CarId)
            {
                return BadRequest();
            }

            _context.Entry(carMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarMasterExists(id))
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

        // POST: api/CarMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarMaster>> PostCarMaster(CarMaster carMaster)
        {
          if (_context.CarMaster == null)
          {
              return Problem("Entity set 'FleetContext.CarMaster'  is null.");
          }
            _context.CarMaster.Add(carMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarMaster", new { id = carMaster.CarId }, carMaster);
        }

        // DELETE: api/CarMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarMaster(int? id)
        {
            if (_context.CarMaster == null)
            {
                return NotFound();
            }
            var carMaster = await _context.CarMaster.FindAsync(id);
            if (carMaster == null)
            {
                return NotFound();
            }

            _context.CarMaster.Remove(carMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarMasterExists(int? id)
        {
            return (_context.CarMaster?.Any(e => e.CarId == id)).GetValueOrDefault();
        }
    }
}
