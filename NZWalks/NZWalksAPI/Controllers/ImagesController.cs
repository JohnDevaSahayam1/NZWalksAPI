using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.CustomActionFilter;
using NZWalksAPI.Models.DTO.Image;
using NZWalksAPI.Repositories.IRepository;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        // POST: api/Images/UploadImage
        [HttpPost("UploadImage")]
        [ValidateModel]
        public async Task<IActionResult> UploadImage([FromForm] ImageUploadRequestDTO imageUpload)
        {
            ValidateImageFile(imageUpload);

            //Covert DTO To DoaminModel
            var imageDomainModel = new Models.Domain.Image
            {
                File = imageUpload.File,
                FileName = imageUpload.FileName,
                FileDescription = imageUpload.FileDescription,
                FileExtension = Path.GetExtension(imageUpload.File.FileName),
                FileSizeInByte = imageUpload.File.Length
            };

            var savedImage = await imageRepository.UploadImageAsync(imageDomainModel);

            return CreatedAtAction(nameof(UploadImage), new { id = savedImage.Id }, savedImage);

        }


        private void ValidateImageFile(ImageUploadRequestDTO imageFile)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };

            var fileExtension = Path.GetExtension(imageFile.File.FileName).ToLower();

            // Validate extension
            if (!allowedExtensions.Contains(fileExtension))
            {
                throw new Exception("Unsupported file format. Allowed formats: " + string.Join(", ", allowedExtensions));
            }

            // Validate size
            var maxFileSizeInBytes = 5 * 1024 * 1024; // 5 MB
            if (imageFile.File.Length > maxFileSizeInBytes)
            {
                throw new Exception("File size exceeds 5 MB.");
            }
        }

    }
}
