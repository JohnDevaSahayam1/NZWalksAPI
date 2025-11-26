using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories.IRepository
{
    public interface IImageRepository
    {
        Task<Image> UploadImageAsync(Image image);
    }
}
