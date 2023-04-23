using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Model
{
    public class ConfirmBooking
    {
        [Key]
        public int? CustomerId { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        
        public long? PhoneNum { get; set; }

       
        public DateTime BookingDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string?  CarTypeName { get; set; }

        public string? HubName { get; set; }
        public string? AddOnName { get; set; }
    }
}
