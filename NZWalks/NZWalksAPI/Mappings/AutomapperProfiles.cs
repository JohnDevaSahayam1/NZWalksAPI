using AutoMapper;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO.Difficulty;
using NZWalksAPI.Models.DTO.Region;
using NZWalksAPI.Models.DTO.Walk;

namespace NZWalksAPI.Mappings
{
    public class AutomapperProfiles:Profile
    {
        public AutomapperProfiles()
        {
            // Region Mappings
            CreateMap<Regiondto, Region>().ReverseMap();
            CreateMap<AddRegionRequestdto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestdto, Region>().ReverseMap();

            // Walk Mappings
            CreateMap<WalkDTO, Walk>().ReverseMap();
            CreateMap<AddWalkRequestDTO, Walk>().ReverseMap();
            CreateMap<UpdateWalkRequestDTO, Walk>().ReverseMap();

            // Difficulty mappings 
            CreateMap<Difficulty, DifficultyDTO>().ReverseMap();

        }
    }
}
