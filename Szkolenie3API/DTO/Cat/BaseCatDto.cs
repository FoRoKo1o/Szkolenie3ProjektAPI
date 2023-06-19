using System.ComponentModel.DataAnnotations;

namespace Szkolenie3API.DTO.Cat
{
    public class BaseCatDto
    {
        [Required]
        [MaxLength(100)]
        public string Breed { get; set; }
        [Range(0, 100)]
        public double Weight { get; set; }
        [MaxLength(50)]
        public string Color { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
