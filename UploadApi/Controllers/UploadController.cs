using Microsoft.AspNetCore.Mvc;
using UploadApi.Models;
using UploadApi.Services.ImageUpload;

namespace UploadApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        public IImageUpload ImageUpload { get; set; }

        public UploadController(IImageUpload imageUpload)
        {
            ImageUpload = imageUpload;
        }

        [HttpPost("[action]")]
        public IActionResult UploadImage([FromForm] Dto dto)
        {
            string? businessPic1 = null;
            string? businessPic2 = null;
            string? businessPic3 = null;
            string? modirPic = null;
            string? visitCartBack = null;
            string? visitCartFront = null;
            switch (dto.businessPics?.Count)
            {
                case 1:
                    businessPic1 = ImageUpload.UploadImage(dto.businessPics[0]);
                    break;
                case 2:
                    businessPic1 = ImageUpload.UploadImage(dto.businessPics[0]);
                    businessPic2 = ImageUpload.UploadImage(dto.businessPics[1]);
                    break;
                case 3:
                    businessPic1 = ImageUpload.UploadImage(dto.businessPics[0]);
                    businessPic2 = ImageUpload.UploadImage(dto.businessPics[1]);
                    businessPic3 = ImageUpload.UploadImage(dto.businessPics[2]);
                    break;
            }

            if (dto.modirPic?.Length > 0)
                modirPic = ImageUpload.UploadImage(dto.modirPic);
            switch (dto.visitCartPics?.Count)
            {
                case 1:
                    visitCartFront = ImageUpload.UploadImage(dto.visitCartPics[0]);
                    break;
                case 2:
                    visitCartFront = ImageUpload.UploadImage(dto.visitCartPics[0]);
                    visitCartBack = ImageUpload.UploadImage(dto.visitCartPics[1]);
                    break;
            }

            return Ok(new { businessPic1, businessPic2, businessPic3, modirPic, visitCartFront, visitCartBack });
        }
    }
}
