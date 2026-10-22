using HelloLocal.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloLocal.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<LocalGuide> Guides { get; set; }
        public DbSet<TourExperience> Experiences { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}