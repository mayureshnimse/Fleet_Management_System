using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FleetManagement.Model
{
    public class HubMaster
    {
        [Key]
        public int? HubId { get; set; }
        public string? HubName { get; set; }

        public string? HubAddress { get; set; }

        [ForeignKey("CityMaster")]
        public int? CityId { get; set; }

        [ForeignKey("StateMaster")]
        public int? StateId { get; set; }

        public IList<AirportMaster>? AirportMaster { get; set; }

        public IList<CarMaster>? CarMaster { get; set; }

        public CityMaster? CityMaster { get; set; }

        public StateMaster? StateMaster { get; set; }

    }
}
