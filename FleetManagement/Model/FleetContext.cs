using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using FleetManagement.Model;

namespace FleetManagement.Model
{
    public class FleetContext : DbContext
    {
        public FleetContext() { }

        public FleetContext(DbContextOptions<FleetContext> options) : base(options) { }



        public DbSet<AddOnMaster> AddOnMaster { get; set; }
        public DbSet<AirportMaster> AirportMaster { get; set; }

        public DbSet<BookingDetail> BookingDetail { get; set; }
        public DbSet<BookingHeader> BookingHeader { get; set; }
        public DbSet<CarMaster> CarMaster { get; set; }
        public DbSet<CarTypeMaster> CarTypeMaster { get; set; }
        public DbSet<CityMaster> CityMaster { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<HubMaster> HubMaster { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetail { get; set; }
        public DbSet<InvoiceHeader> InvoiceHeader { get; set; }
        public DbSet<StateMaster> StateMaster { get; set; }
        public DbSet<FleetManagement.Model.Login> Login { get; set; } = default!;
        public DbSet<FleetManagement.Model.Staff> Staff { get; set; } = default!;

    }
}
