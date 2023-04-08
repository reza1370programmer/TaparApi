
namespace UploadApi.Services.ImageUpload
{
    public interface IImageUpload
    {
        string UploadImage(IFormFile file);
        Task<string> UpdateImage(IFormFile file, string OldImageName);
        Task DeleteImage(string ImageName);
        string ImageResize(Image img, int MaxWidth, int MaxHeight);
    }
}
