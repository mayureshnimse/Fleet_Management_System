using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FleetManagement.Model
{
    public class InvoiceHeader
    {
        [Key]
        public int? InvoiceId { get; set; }

        [ForeignKey("BookingHeader")]
        public int? BookingId { get; set; }

        public DateTime? Odate { get; set; }

        [ForeignKey("Customers")]
        public int? CustomerId { get; set; }

        public DateTime? HandoverDate { get; set; }

        [ForeignKey("CarMaster")]
        public int? CarId { get; set; }

        public DateTime? ReturnDate { get; set; }

        public double? RentalAmount { get; set; }

        public double? TotalAddOnAmount { get; set; }

        public double? TotalAmount { get; set; }

        public String? CustomerDetail { get; set; }

        public BookingHeader? BookingHeader { get; set; }

        public CarMaster? CarMaster { get; set; }

        public Customers? Customers { get; set; }

        public IList<InvoiceDetail>? InvoiceDetail { get; set; }

    }
}
