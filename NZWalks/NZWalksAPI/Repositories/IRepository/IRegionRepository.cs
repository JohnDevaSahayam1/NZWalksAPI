using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories.IRepository
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllRegionsAsync(string? filterOn=null, string? filterQuery = null);

        Task<Region?> GetRegionByIdAsync(Guid id);

       Task<Region> CreateRegionAsync(Region region);
        Task<Region?> UpdateRegionAsync(Guid id, Region region);
        Task<Region?> DeleteRegionAsync(Guid id);
    }
}
