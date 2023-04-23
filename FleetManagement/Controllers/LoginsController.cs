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
    public class LoginsController : ControllerBase
    {
        private readonly FleetContext _context;

        public LoginsController(FleetContext context)
        {
            _context = context;
        }


        // POST: api/Logins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Login>>> PostLogin(Login login)
        {
            if (login == null)
            {
                return Problem("Enter Data to Login");
            }


            var customer = await _context.Customers.FirstOrDefaultAsync((customer) => customer.UserId == login.UserId && customer.Password == login.Password);

            if (customer == null)
            {
                return BadRequest("User not valid");
            }
            else
                if (login.UserId.Equals(customer.UserId) && login.Password.Equals(customer.Password))
            {
                return Ok(customer);
            }

            return BadRequest("Invalid Userid. OR Password");


        }


    }
}
