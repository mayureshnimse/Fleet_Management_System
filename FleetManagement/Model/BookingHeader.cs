using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FleetManagement.Model
{
    public class BookingHeader
    {
        [Key]
        public int? BookingId { get; set; }

        public DateTime? BookingDate { get; set; }

        [ForeignKey("Customers")]
        public int? CustomerId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [ForeignKey("CarTypeMaster")]
        public int? CarTypeId { get; set; }

        public IList<InvoiceHeader>? InvoiceHeader { get; set; }

        public Customers? Customers { get; set; }

        public CarTypeMaster? CarTypeMaster { get; set; }
    }
}
