using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Model
{
    public class Staff
    {
      
            [Key]
            public int BookingId { get; set; }

        
        public string? FirstName { get; set; }

            public string? LastName { get; set; }

             public string? EmailId { get; set; }


            public long? PhoneNum { get; set; }
        public DateTime? PickUpDate { get; set; }

        public DateTime? DropOffDate { get; set; }

        public string? CityName { get; set; }

            public string? HubName { get; set; }

            public string? CarTypeName { get; set; }

  
            public string? CarName { get; set; }

            public string? AddOnName { get; set; }

            // [Index(IsUnique = true)]
            public string? License { get; set; }

            

        }
    }


