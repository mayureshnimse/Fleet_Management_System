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
    public class CityMastersController : ControllerBase
    {
        private readonly FleetContext _context;

        public CityMastersController(FleetContext context)
        {
            _context = context;
        }

        // GET: api/CityMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityMaster>>> GetCityMaster()
        {
          if (_context.CityMaster == null)
          {
              return NotFound();
          }
            return await _context.CityMaster.ToListAsync();
        }

        // GET: api/CityMasters/5
        [HttpGet("{id}")]
         public async Task<ActionResult<CityMaster>> GetCityMaster(int? id)
        {/*
           if (_context.CityMaster == null)
           {
               return NotFound();
           }
             var cityMaster = await _context.CityMaster.FindAsync(id);

             if (cityMaster == null)
             {
                 return NotFound();
             }

             return cityMaster;
         }*/
            var query = await _context.CityMaster
          .Join(_context.StateMaster, c => c.StateId, s => s.StateId, (c, s) => new { c, s })
          .Where(cs => cs.s.StateId == id)
          .Select(cs => cs.c.CityName)
          .ToListAsync();

            return Ok(query);





         

    }

    // PUT: api/CityMasters/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
        public async Task<IActionResult> PutCityMaster(int? id, CityMaster cityMaster)
        {
            if (id != cityMaster.CityId)
            {
                return BadRequest();
            }

            _context.Entry(cityMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityMasterExists(id))
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

        // POST: api/CityMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CityMaster>> PostCityMaster(CityMaster cityMaster)
        {
          if (_context.CityMaster == null)
          {
              return Problem("Entity set 'FleetContext.CityMaster'  is null.");
          }
            _context.CityMaster.Add(cityMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCityMaster", new { id = cityMaster.CityId }, cityMaster);
        }

        // DELETE: api/CityMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCityMaster(int? id)
        {
            if (_context.CityMaster == null)
            {
                return NotFound();
            }
            var cityMaster = await _context.CityMaster.FindAsync(id);
            if (cityMaster == null)
            {
                return NotFound();
            }

            _context.CityMaster.Remove(cityMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CityMasterExists(int? id)
        {
            return (_context.CityMaster?.Any(e => e.CityId == id)).GetValueOrDefault();
        }
    }
}
