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
    public class AddOnMastersController : ControllerBase
    {
        private readonly FleetContext _context;

        public AddOnMastersController(FleetContext context)
        {
            _context = context;
        }

        // GET: api/AddOnMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddOnMaster>>> GetAddOnMaster()
        {
          if (_context.AddOnMaster == null)
          {
              return NotFound();
          }
            return await _context.AddOnMaster.ToListAsync();
        }

        // GET: api/AddOnMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddOnMaster>> GetAddOnMaster(int? id)
        {
          if (_context.AddOnMaster == null)
          {
              return NotFound();
          }
            var addOnMaster = await _context.AddOnMaster.FindAsync(id);

            if (addOnMaster == null)
            {
                return NotFound();
            }

            return addOnMaster;
        }

        // PUT: api/AddOnMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddOnMaster(int? id, AddOnMaster addOnMaster)
        {
            if (id != addOnMaster.AddOnId)
            {
                return BadRequest();
            }

            _context.Entry(addOnMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddOnMasterExists(id))
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

        // POST: api/AddOnMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddOnMaster>> PostAddOnMaster(AddOnMaster addOnMaster)
        {
          if (_context.AddOnMaster == null)
          {
              return Problem("Entity set 'FleetContext.AddOnMaster'  is null.");
          }
            _context.AddOnMaster.Add(addOnMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddOnMaster", new { id = addOnMaster.AddOnId }, addOnMaster);
        }

        // DELETE: api/AddOnMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddOnMaster(int? id)
        {
            if (_context.AddOnMaster == null)
            {
                return NotFound();
            }
            var addOnMaster = await _context.AddOnMaster.FindAsync(id);
            if (addOnMaster == null)
            {
                return NotFound();
            }

            _context.AddOnMaster.Remove(addOnMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddOnMasterExists(int? id)
        {
            return (_context.AddOnMaster?.Any(e => e.AddOnId == id)).GetValueOrDefault();
        }
    }
}
