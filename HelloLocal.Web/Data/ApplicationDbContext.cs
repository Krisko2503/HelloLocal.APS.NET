using HelloLocal.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HelloLocal.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<LocalGuide> Guides { get; set; }
        public DbSet<TourExperience> Experiences { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<LocalGuide> LocalGuides { get; set; }
        public DbSet<TourExperience> TourExperiences { get; set; }
    }
}