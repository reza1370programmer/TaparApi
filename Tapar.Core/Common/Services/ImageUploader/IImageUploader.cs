
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Tapar.Core.Common.Services.ImageUploader
{
    [ScopedService]
    public interface IImageUploader
    {
        Task<string> UploadImage(IFormFile file);
        Task<string> UpdateImage(IFormFile file,string OldImageName);
        Task DeleteImage(string ImageName);
        string ImageResize(Image img,int MaxWidth,int MaxHeight);
    }
}
