using System;
using System.Linq;
using HelloLocal.Web.Models;

namespace HelloLocal.Web.Data
{
    public static class DataSeeder
    {
        public static void Seed(ApplicationDbContext dbContext)
        {
            if (dbContext.LocalGuides.Any())
                return;

            var guide1 = new LocalGuide
            {
                Name = "Ivan Ivanov",
                City = "Pleven",
                Bio = "Experienced local guide focusing on historical landmarks and urban culture.",
                HourlyRate = 25m
            };

            var guide2 = new LocalGuide();
            guide2.Name = "Maria Marinova";
            guide2.City = "Sofia";
            guide2.Bio = "Professional photographer offering scenic walking tours and visual storytelling.";
            guide2.HourlyRate = 30m;

            var guide3 = new LocalGuide
            {
                Name = "Georgi Georgiev",
                City = "Varna",
                Bio = "Specializing in seaside walks, maritime history, and culinary experiences.",
                HourlyRate = 20m
            };

            dbContext.LocalGuides.AddRange(guide1, guide2, guide3);
            dbContext.SaveChanges();

            var tour1 = new TourExperience
            {
                Title = "Historical Center Tour",
                Description = "A comprehensive walking tour through the main historical landmarks with scheduled breaks.",
                Price = 20.00m,
                LocalGuideId = guide1.Id
            };

            var tour2 = new TourExperience();
            tour2.Title = "Urban Photography Walk";
            tour2.Description = "Discover the best urban architecture spots for photography. Suitable for all skill levels.";
            tour2.Price = 50.00m;
            tour2.LocalGuideId = guide2.Id;

            var tour3 = new TourExperience
            {
                Title = "Seaside Culture Tour",
                Description = "Evening walk focusing on local maritime history and traditional seafood.",
                Price = 35.00m,
                LocalGuideId = guide3.Id
            };

            dbContext.TourExperiences.Add(tour1);
            dbContext.TourExperiences.Add(tour2);
            dbContext.TourExperiences.Add(tour3);

            dbContext.SaveChanges();

            if (!dbContext.Bookings.Any())
            {
                var booking1 = new Booking
                {
                    TouristName = "Kristiyan",
                    BookingDate = new DateTime(2026, 11, 23, 16, 0, 0),
                    TourExperienceId = tour1.Id
                };

                dbContext.Bookings.Add(booking1);
                dbContext.SaveChanges();
            }
        }
    }
}