using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Entities
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Household> Households { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberType> MemberTypes { get; set; }
        public DbSet<Sport> Sports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*
            // Composite Key for MemberSport
            modelBuilder.Entity<MemberSport>()
                .HasKey(ms => new { ms.MemberId, ms.SportId });
            */

            // Seed MemberType data (hvis nødvendigt)
            modelBuilder.Entity<MemberType>().HasData(
                new MemberType { Id = 1, Name = "Aktivt Medlem" },
                new MemberType { Id = 2, Name = "Passivt Medlem" },
                new MemberType { Id = 3, Name = "Medlem af Bestyrelse" },
                new MemberType { Id = 4, Name = "Forælder" }
            );

            // Seed Sport data
            modelBuilder.Entity<Sport>().HasData(
                new Sport { Id = 1, Name = "Fodbold", MemberShipFee = 800 },
                new Sport { Id = 2, Name = "Håndbold", MemberShipFee = 700 },
                new Sport { Id = 3, Name = "Gymnastik", MemberShipFee = 600 },
                new Sport { Id = 4, Name = "Bamsekarate (Zumba)", MemberShipFee = 500 }
            );
        }

    }
}
