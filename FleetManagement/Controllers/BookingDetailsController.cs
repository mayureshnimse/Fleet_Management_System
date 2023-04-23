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
    public class BookingDetailsController : ControllerBase
    {
        private readonly FleetContext _context;

        public BookingDetailsController(FleetContext context)
        {
            _context = context;
        }

        // GET: api/BookingDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDetail>>> GetBookingDetail()
        {
          if (_context.BookingDetail == null)
          {
              return NotFound();
          }
            return await _context.BookingDetail.ToListAsync();
        }

        // GET: api/BookingDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDetail>> GetBookingDetail(int? id)
        {
            if (_context.BookingDetail == null)
            {
                return NotFound();
            }

            var querry = await _context.Customers
     .Join(_context.BookingHeader, c => c.CustomerId, bh => bh.CustomerId, (c, bh) => new { c, bh })
     .Join(_context.HubMaster, cb => cb.c.CityId, hm => hm.CityId, (cb, hm) => new { cb.c, cb.bh, hm })
     .Join(_context.CarMaster, chm => chm.hm.HubId, cm => cm.HubId, (chm, cm) => new { chm.c, chm.bh, chm.hm, cm })
     .Join(_context.CarTypeMaster, chcm => chcm.cm.CartypeId, ctm => ctm.CarTypeId, (chcm, ctm) => new { chcm.c, chcm.bh, chcm.hm, chcm.cm, ctm })
     .Join(_context.BookingDetail, chcmt => chcmt.bh.BookingId, bd => bd.BookingId, (chcmt, bd) => new { chcmt.c, chcmt.bh, chcmt.hm, chcmt.cm, chcmt.ctm, bd })
     .Where(cd => cd.c.CustomerId == id)
     .Join(_context.AddOnMaster, chcmtbd => chcmtbd.bd.AddOnId, am => am.AddOnId, (chcmtbd, am) => new
     {
         FirstName = chcmtbd.c.FirstName,
         LastName = chcmtbd.c.LastName,
         PhoneNum = chcmtbd.c.PhoneNum,
         BookingDate = chcmtbd.bh.BookingDate,
         StartDate = chcmtbd.bh.StartDate,
         EndDate = chcmtbd.bh.EndDate,
         HubName = chcmtbd.hm.HubName,
         CarTypName = chcmtbd.ctm.CarTypeName,
         AddOnName = am.AddOnName
     })

   
     .ToListAsync();



            return Ok(querry);

        }
        // PUT: api/BookingDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingDetail(int? id, BookingDetail bookingDetail)
        {
            if (id != bookingDetail.BookingDetailId)
            {
                return BadRequest();
            }

            _context.Entry(bookingDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingDetailExists(id))
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

        // POST: api/BookingDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookingDetail>> PostBookingDetail(BookingDetail bookingDetail)
        {
          if (_context.BookingDetail == null)
          {
              return Problem("Entity set 'FleetContext.BookingDetail'  is null.");
          }
            _context.BookingDetail.Add(bookingDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingDetail", new { id = bookingDetail.BookingDetailId }, bookingDetail);
        }

        // DELETE: api/BookingDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingDetail(int? id)
        {
            if (_context.BookingDetail == null)
            {
                return NotFound();
            }
            var bookingDetail = await _context.BookingDetail.FindAsync(id);
            if (bookingDetail == null)
            {
                return NotFound();
            }

            _context.BookingDetail.Remove(bookingDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingDetailExists(int? id)
        {
            return (_context.BookingDetail?.Any(e => e.BookingDetailId == id)).GetValueOrDefault();
        }
    }
}
