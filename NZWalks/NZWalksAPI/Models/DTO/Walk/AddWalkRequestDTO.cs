using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Models.DTO.Walk
{
    public class AddWalkRequestDTO
    {
        [Required]
        [StringLength(150, ErrorMessage = "Name cannot exceed 150 characters.")]
        public string Name { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string Description { get; set; }

        [Required]
        [Range(0.1, 1000, ErrorMessage = "LengthInKm must be between 0.1 and 1000 km.")]
        public double LengthInKm { get; set; }

        [Url(ErrorMessage = "WalkImageUrl must be a valid URL.")]
        public string? WalkImageUrl { get; set; }

        [Required(ErrorMessage = "RegionId is required.")]
        public Guid RegionId { get; set; }

        [Required(ErrorMessage = "DifficultyId is required.")]
        public Guid DifficultyId { get; set; }
    }
}
