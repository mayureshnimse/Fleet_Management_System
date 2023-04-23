using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FleetManagement.Model
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Address { get; set; }

       // [Index(IsUnique = true)]
        public long? PhoneNum { get; set; }

        // [Index(IsUnique = true)]
        public string? Email { get; set; }

        [ForeignKey("CityMaster")]
        public int? CityId { get; set; }

        public int? ZipCode { get; set; }

        public DateTime? DoB { get; set; }

        public int? Age { get; set; }

        public string? Gender { get; set; }

        // [Index(IsUnique = true)]
        public long? AdhaarCardNum { get; set; }

        // [Index(IsUnique = true)]
        public string? UserId { get; set; }

        public string? Password { get; set; }

        // [Index(IsUnique = true)]
        public string? License { get; set; }

        public IList<BookingHeader>? BookingHeader { get; set; }

        public IList<InvoiceHeader>? InvoiceHeader { get; set; }

        public CityMaster? CityMaster { get; set; }

    }
}
