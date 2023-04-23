using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Model
{
    public class StateMaster
    {
        [Key]
        public int? StateId { get; set; }

        public string? StateName { get; set; }

        public IList<AirportMaster>? AirportMaster { get; set; }

        public IList<CityMaster>? CityMaster { get; set; }
        public IList<HubMaster>? HubMaster { get; set; }

    }
}
