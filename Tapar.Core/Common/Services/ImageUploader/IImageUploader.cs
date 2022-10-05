
using Microsoft.AspNetCore.Http;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Tapar.Core.Common.Services.ImageUploader
{
    [ScopedService]
    internal interface IImageUploader
    {
        Task<string> UploadImage(IFormFile file);
    }
}
