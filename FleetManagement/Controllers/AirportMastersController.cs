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
    public class AirportMastersController : ControllerBase
    {
        private readonly FleetContext _context;

        public AirportMastersController(FleetContext context)
        {
            _context = context;
        }

        // GET: api/AirportMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirportMaster>>> GetAirportMaster()
        {
          if (_context.AirportMaster == null)
          {
              return NotFound();
          }
            return await _context.AirportMaster.ToListAsync();
        }

        // GET: api/AirportMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AirportMaster>> GetAirportMaster(int? id)
        {
          if (_context.AirportMaster == null)
          {
              return NotFound();
          }
            var airportMaster = await _context.AirportMaster.FindAsync(id);

            if (airportMaster == null)
            {
                return NotFound();
            }

            return airportMaster;
        }

        // PUT: api/AirportMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirportMaster(int? id, AirportMaster airportMaster)
        {
            if (id != airportMaster.AirportId)
            {
                return BadRequest();
            }

            _context.Entry(airportMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirportMasterExists(id))
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

        // POST: api/AirportMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AirportMaster>> PostAirportMaster(AirportMaster airportMaster)
        {
          if (_context.AirportMaster == null)
          {
              return Problem("Entity set 'FleetContext.AirportMaster'  is null.");
          }
            _context.AirportMaster.Add(airportMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAirportMaster", new { id = airportMaster.AirportId }, airportMaster);
        }

        // DELETE: api/AirportMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirportMaster(int? id)
        {
            if (_context.AirportMaster == null)
            {
                return NotFound();
            }
            var airportMaster = await _context.AirportMaster.FindAsync(id);
            if (airportMaster == null)
            {
                return NotFound();
            }

            _context.AirportMaster.Remove(airportMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AirportMasterExists(int? id)
        {
            return (_context.AirportMaster?.Any(e => e.AirportId == id)).GetValueOrDefault();
        }
    }
}
