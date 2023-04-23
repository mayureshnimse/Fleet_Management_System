using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Model
{
    public class AddOnMaster
    {
        [Key]
        public int? AddOnId { get; set; }

        public string? AddOnName { get; set; }
        public double? AddOnDailyRate { get; set; }
        public DateTime? RateValidUpto { get; set; }

        public IList<BookingDetail>? BookingDetail { get; set; }
        public IList<InvoiceDetail>? InvoiceDetail { get; set; }

    }


}
