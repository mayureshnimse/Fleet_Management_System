using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Model
{
    public class CityMaster
    {
        [Key]
        public int? CityId { get; set; }
        public string? CityName { get; set; }

        [ForeignKey("StateMaster")]
        public int? StateId { get; set; }

        public IList<AirportMaster>? AirportMaster { get; set; }

        public IList<Customers>? Customers { get; set; }
        public IList<HubMaster>? HubMaster { get; set; }

        public StateMaster? StateMaster { get; set; }

    }
}
