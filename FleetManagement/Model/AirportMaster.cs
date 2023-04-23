using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Model
{
    public class AirportMaster
    {
        [Key]
        public int? AirportId { get; set; }

        public string? AirportName { get; set; }

        [ForeignKey("CityMaster")]
        public int? CityId { get; set; }

        [ForeignKey("StateMaster")]
        public int? StateId { get; set; }

        [ForeignKey("HubMaster")]
        public int? HubId { get; set; }
        public int? AirportCode { get; set; }



        public HubMaster? HubMaster { get; set; }
        public CityMaster? CityMaster { get; set; }
        public StateMaster? StateMaster { get; set; }
    }
}
