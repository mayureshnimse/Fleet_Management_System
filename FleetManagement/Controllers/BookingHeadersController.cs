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
    public class BookingHeadersController : ControllerBase
    {
        private readonly FleetContext _context;

        public BookingHeadersController(FleetContext context)
        {
            _context = context;
        }

        // GET: api/BookingHeaders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingHeader>>> GetBookingHeader()
        {
          if (_context.BookingHeader == null)
          {
              return NotFound();
          }
            return await _context.BookingHeader.ToListAsync();
        }

        // GET: api/BookingHeaders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingHeader>> GetBookingHeader(int? id)
        {
          if (_context.BookingHeader == null)
          {
              return NotFound();
          }
            var bookingHeader = await _context.BookingHeader.FindAsync(id);

            if (bookingHeader == null)
            {
                return NotFound();
            }

            return bookingHeader;
        }

        // PUT: api/BookingHeaders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingHeader(int? id, BookingHeader bookingHeader)
        {
            if (id != bookingHeader.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(bookingHeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingHeaderExists(id))
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

        // POST: api/BookingHeaders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookingHeader>> PostBookingHeader(BookingHeader bookingHeader)
        {
          if (_context.BookingHeader == null)
          {
              return Problem("Entity set 'FleetContext.BookingHeader'  is null.");
          }
            _context.BookingHeader.Add(bookingHeader);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingHeader", new { id = bookingHeader.BookingId }, bookingHeader);
        }

        // DELETE: api/BookingHeaders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingHeader(int? id)
        {
            if (_context.BookingHeader == null)
            {
                return NotFound();
            }
            var bookingHeader = await _context.BookingHeader.FindAsync(id);
            if (bookingHeader == null)
            {
                return NotFound();
            }

            _context.BookingHeader.Remove(bookingHeader);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingHeaderExists(int? id)
        {
            return (_context.BookingHeader?.Any(e => e.BookingId == id)).GetValueOrDefault();
        }
    }
}
