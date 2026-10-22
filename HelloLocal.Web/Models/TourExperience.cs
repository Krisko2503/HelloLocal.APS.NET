using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloLocal.Web.Models
{
    public class TourExperience
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public int LocalGuideId { get; set; }
        [ForeignKey("LocalGuideId")]
        public LocalGuide Guide { get; set; }
    }
}