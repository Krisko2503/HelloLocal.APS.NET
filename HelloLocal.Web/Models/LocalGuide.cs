using System.ComponentModel.DataAnnotations;

namespace HelloLocal.Web.Models
{
    public class LocalGuide
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string Bio { get; set; }

        [Required]
        public decimal HourlyRate { get; set; }

        public List<TourExperience> Experiences { get; set; } = new List<TourExperience>();
    }
}