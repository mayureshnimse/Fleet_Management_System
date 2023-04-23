using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace FleetManagement.Model
{
    public class BookingDetail
    {
        [Key]
        public int? BookingDetailId { get; set; }

        [ForeignKey("BookingHeader")]
        public int? BookingId { get; set; }

        [ForeignKey("AddOnMaster")]
        public int? AddOnId { get; set; }

        public double? AddOnRate { get; set; }

        public AddOnMaster? AddOnMaster { get; set; }
    }
}
