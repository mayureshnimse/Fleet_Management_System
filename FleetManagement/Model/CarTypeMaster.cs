using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Model
{
    public class CarTypeMaster
    {
        [Key]
        public int? CarTypeId { get; set; }
        public String? CarTypeName { get; set; }
        public double? DailyRate { get; set; }
        public double? WeeklyRate { get; set; }
        public double? MonthRate { get; set; }
        public string? ImagePath { get; set; }

        public IList<CarMaster>? CarMaster { get; set; }

        public IList<BookingHeader>? BookingHeader { get; set; }



    }

}

