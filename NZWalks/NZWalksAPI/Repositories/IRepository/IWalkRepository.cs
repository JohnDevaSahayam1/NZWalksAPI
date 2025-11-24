using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories.IRepository
{
    public interface IWalkRepository
    {
        Task<Walk> CreateWalkAsync(Walk walk);
        Task<List<Walk>> GetAllWalksAsync(string? FilterOn = null, String? FilerQuery = null,String? Sortby =null, bool? isAscending = true);

        Task<Walk?> GetWalkById(Guid id);

        Task<Walk?> UpdateWalkById(Guid id, Walk walk);
        Task<Walk?> DeleteWalkById(Guid id);
    }
}
