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
    public class InvoiceHeadersController : ControllerBase
    {
        private readonly FleetContext _context;

        public InvoiceHeadersController(FleetContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceHeaders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceHeader>>> GetInvoiceHeader()
        {
          if (_context.InvoiceHeader == null)
          {
              return NotFound();
          }
            return await _context.InvoiceHeader.ToListAsync();
        }

        // GET: api/InvoiceHeaders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceHeader>> GetInvoiceHeader(int? id)
        {
          if (_context.InvoiceHeader == null)
          {
              return NotFound();
          }
            var invoiceHeader = await _context.InvoiceHeader.FindAsync(id);

            if (invoiceHeader == null)
            {
                return NotFound();
            }

            return invoiceHeader;
        }

        // PUT: api/InvoiceHeaders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceHeader(int? id, InvoiceHeader invoiceHeader)
        {
            if (id != invoiceHeader.InvoiceId)
            {
                return BadRequest();
            }

            _context.Entry(invoiceHeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceHeaderExists(id))
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

        // POST: api/InvoiceHeaders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvoiceHeader>> PostInvoiceHeader(InvoiceHeader invoiceHeader)
        {
          if (_context.InvoiceHeader == null)
          {
              return Problem("Entity set 'FleetContext.InvoiceHeader'  is null.");
          }
            _context.InvoiceHeader.Add(invoiceHeader);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoiceHeader", new { id = invoiceHeader.InvoiceId }, invoiceHeader);
        }

        // DELETE: api/InvoiceHeaders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceHeader(int? id)
        {
            if (_context.InvoiceHeader == null)
            {
                return NotFound();
            }
            var invoiceHeader = await _context.InvoiceHeader.FindAsync(id);
            if (invoiceHeader == null)
            {
                return NotFound();
            }

            _context.InvoiceHeader.Remove(invoiceHeader);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoiceHeaderExists(int? id)
        {
            return (_context.InvoiceHeader?.Any(e => e.InvoiceId == id)).GetValueOrDefault();
        }
    }
}
