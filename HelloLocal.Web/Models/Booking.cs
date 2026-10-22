using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloLocal.Web.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the tourist's name!")]
        public string TouristName { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        public int TourExperienceId { get; set; }

        [ForeignKey("TourExperienceId")]
        public TourExperience Experience { get; set; }
    }
}