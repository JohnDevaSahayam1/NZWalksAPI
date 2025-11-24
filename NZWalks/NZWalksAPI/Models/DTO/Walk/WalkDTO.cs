using NZWalksAPI.Models.DTO.Difficulty;
using NZWalksAPI.Models.DTO.Region;

namespace NZWalksAPI.Models.DTO.Walk
{
    public class WalkDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        //public Guid RegionId { get; set; }
        //public Guid DifficultyId { get; set; }

        public Regiondto Region { get; set; }
        public DifficultyDTO Difficulty { get; set; }
    }
}
