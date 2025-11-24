using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Repositories.IRepository;

namespace NZWalksAPI.Repositories.Repository
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalkDbContext dbContext;

        public RegionRepository(NZWalkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Region> CreateRegionAsync(Region region)
        {
            var newRegion = await dbContext.regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteRegionAsync(Guid id)
        {
            var ExistingRegion = await dbContext.regions.FirstOrDefaultAsync(x => x.Id == id);
            if (ExistingRegion == null)
            {
                return null;
            }
            dbContext.regions.Remove(ExistingRegion);
            await dbContext.SaveChangesAsync();
            return ExistingRegion;
        }

        public async Task<List<Region>> GetAllRegionsAsync(string? filterOn = null, string? filterQuery = null)
        {
            var regions = dbContext.regions.AsQueryable();

            // filtering 
            if (!string.IsNullOrWhiteSpace(filterOn) &&
                !string.IsNullOrWhiteSpace(filterQuery))
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    regions = regions.Where(r => r.Name.Contains(filterQuery));
                }
                else if (filterOn.Equals("Code", StringComparison.OrdinalIgnoreCase))
                {
                    regions = regions.Where(r => r.Code.Contains(filterQuery));
                }
            }

            return await regions.ToListAsync();
        }


        public async Task<Region?> GetRegionByIdAsync(Guid id)
        {
            var Region = await dbContext.regions.FirstOrDefaultAsync(x => x.Id == id);
            return Region;
        }

        public async Task<Region?> UpdateRegionAsync(Guid id, Region region)
        {
            var ExistingRegion = await dbContext.regions.FirstOrDefaultAsync(x => x.Id == id);
            if (ExistingRegion == null)
            {
                return null;
            }
            ExistingRegion.Code = region.Code;
            ExistingRegion.Name = region.Name;
            ExistingRegion.RegionImageUrl = region.RegionImageUrl;
            await dbContext.SaveChangesAsync();

            return ExistingRegion;
        }


    }
}
