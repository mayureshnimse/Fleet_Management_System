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
    public class StateMastersController : ControllerBase
    {
        private readonly FleetContext _context;

        public StateMastersController(FleetContext context)
        {
            _context = context;
        }

        // GET: api/StateMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StateMaster>>> GetStateMaster()
        {
          if (_context.StateMaster == null)
          {
              return NotFound();
          }
            return await _context.StateMaster.ToListAsync();
        }

        // GET: api/StateMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StateMaster>> GetStateMaster(int? id)
        {
          if (_context.StateMaster == null)
          {
              return NotFound();
          }
            var stateMaster = await _context.StateMaster.FindAsync(id);

            if (stateMaster == null)
            {
                return NotFound();
            }

            return stateMaster;
        }

        // PUT: api/StateMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStateMaster(int? id, StateMaster stateMaster)
        {
            if (id != stateMaster.StateId)
            {
                return BadRequest();
            }

            _context.Entry(stateMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StateMasterExists(id))
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

        // POST: api/StateMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StateMaster>> PostStateMaster(StateMaster stateMaster)
        {
          if (_context.StateMaster == null)
          {
              return Problem("Entity set 'FleetContext.StateMaster'  is null.");
          }
            _context.StateMaster.Add(stateMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStateMaster", new { id = stateMaster.StateId }, stateMaster);
        }

        // DELETE: api/StateMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStateMaster(int? id)
        {
            if (_context.StateMaster == null)
            {
                return NotFound();
            }
            var stateMaster = await _context.StateMaster.FindAsync(id);
            if (stateMaster == null)
            {
                return NotFound();
            }

            _context.StateMaster.Remove(stateMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StateMasterExists(int? id)
        {
            return (_context.StateMaster?.Any(e => e.StateId == id)).GetValueOrDefault();
        }
    }
}
