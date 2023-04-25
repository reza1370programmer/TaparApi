using FluentFTP;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System.IO;

namespace Tapar.Core.Common.Services.ImageUploader
{
    public class ImageUploader : IImageUploader
    {


        public async Task<string> UploadImage(IFormFile file)
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
                    //var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")).Root + $@"\{newFileName}";
                    using (var image = Image.Load(file.OpenReadStream()))
                    {

                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            var encoder = new JpegEncoder()
                            {
                                Quality = 30 //Use variable to set between 5-30 based on your requirements
                            };
                            string newsize = ImageResize(image, 800, 600);
                            string[] sizearray = newsize.Split(',');
                            image.Mutate(x => x.Resize(Convert.ToInt32(sizearray[1]), Convert.ToInt32(sizearray[0])));
                            image.Save(memoryStream, encoder);
                            //memoryStream.Position = 0;
                            memoryStream.Seek(0, SeekOrigin.Begin);
                            var client = new AsyncFtpClient("185.49.85.16", "dltapari", "YTWGHrfu87ghjy90r");
                            await client.AutoConnect();
                            client.Config.EncryptionMode = FtpEncryptionMode.Explicit;
                            client.Config.ValidateAnyCertificate = true;
                            await client.UploadStream(memoryStream, $"/www/images/{newFileName}");
                            await memoryStream.DisposeAsync();
                            await client.Disconnect();
                        }
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
                    newFileName = await UploadImage(file);
                    await DeleteImage(OldImageName);
                }
                else return null!;

                return newFileName;
            }
            else return null!;
        }
        public async Task DeleteImage(string ImageName)
        {
            var client = new AsyncFtpClient("185.49.85.16", "dltapari", "YTWGHrfu87ghjy90r");
            await client.AutoConnect();
            client.Config.EncryptionMode = FtpEncryptionMode.Explicit;
            client.Config.ValidateAnyCertificate = true;
            if (!string.IsNullOrEmpty(ImageName))
                if (await client.FileExists($"/www/images/{ImageName}"))
                    await client.DeleteFile($"/www/images/{ImageName}");
            await client.Disconnect();
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
