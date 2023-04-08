namespace UploadApi.Models
{
    public class Dto
    {
        public List<IFormFile>? businessPics { get; set; }
        public IFormFile? modirPic { get; set; }
        public List<IFormFile>? visitCartPics { get; set; }
    }
}
