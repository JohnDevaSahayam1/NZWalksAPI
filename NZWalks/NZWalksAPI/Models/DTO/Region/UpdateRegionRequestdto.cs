using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Models.DTO.Region
{
    public class UpdateRegionRequestdto
    {
        [Required]
        [StringLength(5, ErrorMessage = "Code cannot be longer than 5 characters.")]
        public string Code { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
