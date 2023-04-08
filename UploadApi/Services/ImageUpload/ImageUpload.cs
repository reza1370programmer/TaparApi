using Microsoft.Extensions.FileProviders;
namespace UploadApi.Services.ImageUpload
{
    public class ImageUpload:IImageUpload
    {
        public string UploadImage(IFormFile file)
        {
            string newFileName = "";
            if (file != null)
            {
                if (file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var guid = Convert.ToString(Guid.NewGuid().ToString("N"));
                    var now = DateTime.Now.TimeOfDay.Ticks;
                    var myUniqueFileName = $"{guid}_{now}";
                    var fileExtension = Path.GetExtension(fileName);
                    newFileName = String.Concat(myUniqueFileName, fileExtension);
                    var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")).Root + $@"\{newFileName}";
                    using (var image = Image.Load(file.OpenReadStream()))
                    {
                        string newsize = ImageResize(image, 800, 600);
                        string[] sizearray = newsize.Split(',');
                        image.Mutate(x => x.Resize(Convert.ToInt32(sizearray[1]), Convert.ToInt32(sizearray[0])));
                        image.Save(filepath);
                    }
                }
                else return null!;

                return newFileName;
            }
            else return null!;
        }
        public async Task<string> UpdateImage(IFormFile file, string OldImageName)
        {
            string newFileName = "";
            if (file != null)
            {
                if (file.Length > 0)
                {

                    var fileName = Path.GetFileName(file.FileName);
                    var guid = Convert.ToString(Guid.NewGuid().ToString("N"));
                    var now = DateTime.Now.TimeOfDay.Ticks;
                    var myUniqueFileName = $"{guid}_{now}";
                    var fileExtension = Path.GetExtension(fileName);
                    newFileName = String.Concat(myUniqueFileName, fileExtension);
                    var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")).Root + $@"\{newFileName}";
                    using (var image = Image.Load(file.OpenReadStream()))
                    {
                        string newsize = ImageResize(image, 800, 600);
                        string[] sizearray = newsize.Split(',');
                        image.Mutate(x => x.Resize(Convert.ToInt32(sizearray[1]), Convert.ToInt32(sizearray[0])));
                        image.Save(filepath);
                    }

                    string oldPath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")).Root + $@"\{OldImageName}";
                    if (File.Exists(oldPath))
                    {
                        File.Delete(oldPath);
                    }
                }
                else return null!;

                return newFileName;
            }
            else return null!;
        }
        public Task DeleteImage(string ImageName)
        {
            var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")).Root + $@"\{ImageName}";
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
            return Task.CompletedTask;
        }
        public string ImageResize(Image img, int MaxWidth, int MaxHeight)
        {
            if (img.Width > MaxWidth || img.Height > MaxHeight)
            {
                double WidthRatio = (double)img.Width / (double)MaxWidth;
                double HeightRatio = (double)img.Height / (double)MaxHeight;
                double Ratio = Math.Max(WidthRatio, HeightRatio);
                int NewWidth = (int)(img.Width / Ratio);
                int NewHeigth = (int)(img.Height / Ratio);
                return NewHeigth.ToString() + "," + NewWidth.ToString();

            }
            else
                return img.Height.ToString() + "," + img.Width.ToString();

        }
    }
}
