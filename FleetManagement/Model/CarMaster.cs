using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Model
{
    public class CarMaster
    {
        [Key]
        public int? CarId { get; set; }

        [ForeignKey("CarTypeMaster")]
        public int? CartypeId { get; set; }

        [ForeignKey("HubMaster")]
        public int? HubId { get; set; }
        public string? CarDetail { get; set; }

        public string? IsAvailable { get; set; }
        public DateTime? MaintenanceDueDate { get; set; }
        public CarTypeMaster? CarTypeMaster { get; set; }

        public HubMaster? HubMaster { get; set; }

        public IList<InvoiceHeader>? InvoiceHeader { get; set; }
    }


}
