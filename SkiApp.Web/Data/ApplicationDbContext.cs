using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkiApp.Domain.DomainModels;
using SkiApp.Domain.Identity;

namespace SkiApp.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<SkiResortApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SkiResort> SkiResorts { get; set; }
        public virtual DbSet<SkiPass> SkiPasses { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }

    }
}
