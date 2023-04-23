using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FleetManagement.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FleetManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HubMastersController : ControllerBase
    {
        private readonly FleetContext _context;

        public HubMastersController(FleetContext context)
        {
            _context = context;
        }

        // GET: api/HubMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HubMaster>>> GetHubMaster()
        {
          if (_context.HubMaster == null)
          {
              return NotFound();
          }
            return await _context.HubMaster.ToListAsync();
        }

        // GET: api/HubMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HubMaster>> GetHubMaster(string? id)
        {
            /*if (_context.HubMaster == null)
            {
                return NotFound();
            }
              var hubMaster = await _context.HubMaster.FindAsync(id);

              if (hubMaster == null)
              {
                  return NotFound();
              }

              return hubMaster;*/
            var hubNames = await _context.HubMaster
     .Join(_context.CityMaster,
           hub => hub.CityId,
           city => city.CityId,
           (hub, city) => new { Hub = hub, City = city })
     .Where(hubCity => hubCity.City.CityName == id)
     .Select(hubCity => hubCity.Hub.HubName)
     .ToListAsync();
            return Ok(hubNames);
        }

        // PUT: api/HubMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHubMaster(int? id, HubMaster hubMaster)
        {
            if (id != hubMaster.HubId)
            {
                return BadRequest();
            }

            _context.Entry(hubMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HubMasterExists(id))
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

        // POST: api/HubMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HubMaster>> PostHubMaster(HubMaster hubMaster)
        {
          if (_context.HubMaster == null)
          {
              return Problem("Entity set 'FleetContext.HubMaster'  is null.");
          }
            _context.HubMaster.Add(hubMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHubMaster", new { id = hubMaster.HubId }, hubMaster);
        }

        // DELETE: api/HubMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHubMaster(int? id)
        {
            if (_context.HubMaster == null)
            {
                return NotFound();
            }
            var hubMaster = await _context.HubMaster.FindAsync(id);
            if (hubMaster == null)
            {
                return NotFound();
            }

            _context.HubMaster.Remove(hubMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HubMasterExists(int? id)
        {
            return (_context.HubMaster?.Any(e => e.HubId == id)).GetValueOrDefault();
        }
    }
}
