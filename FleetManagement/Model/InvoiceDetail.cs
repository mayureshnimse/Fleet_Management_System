using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FleetManagement.Model
{
    public class InvoiceDetail
    {
        [Key]
        public int? InvoiceDetailId { get; set; }

        [ForeignKey("InvoiceHeader")]
        public int? InvoiceId { get; set; }

        [ForeignKey("AddOnMaster")]

        public int? AddOnId { get; set; }

        public double? AddOnAmount { get; set; }

        public AddOnMaster? AddOnMaster { get; set; }

        public InvoiceHeader? InvoiceHeader { get; set; }

    }
}
