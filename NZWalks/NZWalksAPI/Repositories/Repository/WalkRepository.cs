using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Repositories.IRepository;

namespace NZWalksAPI.Repositories.Repository
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalkDbContext dbContext;

        public WalkRepository(NZWalkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Walk> CreateWalkAsync(Walk walk)
        {
            await dbContext.walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllWalksAsync(string? filterOn = null, string? filterQuery = null, String? Sortby=null, bool? isAscending = true, int? pageNumber = 1, int? pageSize = 1000)
        {
           
            var walks = dbContext.walks .Include("Region").Include("Difficulty") .AsQueryable();

            //  filtering 
            if (!string.IsNullOrWhiteSpace(filterOn) &&
                !string.IsNullOrWhiteSpace(filterQuery))
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
                else if (filterOn.Equals("Description", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Description.Contains(filterQuery));
                }
            }

            //sorting
            if (!string.IsNullOrWhiteSpace(Sortby))
            {
                if (Sortby.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending == true ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                }
                else if (Sortby.Equals("LengthInKm", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending == true ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
                }
            }



            //Pagination
            if (pageNumber.HasValue && pageSize.HasValue)
            {
                var skipResults = (pageNumber.Value - 1) * pageSize.Value;
                walks = walks.Skip(skipResults).Take(pageSize.Value);
            }

            return await walks.ToListAsync();
        }

        public async Task<Walk?> GetWalkById(Guid id)
        {
            var Walk = await dbContext.walks.Include("Region").Include("Difficulty").FirstOrDefaultAsync(x => x.Id == id);

            if (Walk == null)
            {
                return null;
            }

            return Walk;
        }

        public async Task<Walk?> UpdateWalkById(Guid id, Walk walk)
        {
            var existingWalk = await dbContext.walks.FindAsync(id);
            if (existingWalk == null)
            {
                return null;
            }

            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.RegionId = walk.RegionId;
            existingWalk.DifficultyId = walk.DifficultyId;
            await dbContext.SaveChangesAsync();

            return existingWalk;
        }


        public async Task<Walk?> DeleteWalkById(Guid id)
        {
            var WalkExist = await dbContext.walks.FirstOrDefaultAsync(x => x.Id == id);
            if (WalkExist == null)
            {
                return null;
            }

            dbContext.walks.Remove(WalkExist);
            await dbContext.SaveChangesAsync();
            return WalkExist;
        }

    }
}
