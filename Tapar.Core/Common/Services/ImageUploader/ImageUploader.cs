

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace Tapar.Core.Common.Services.ImageUploader
{
    internal class ImageUploader : IImageUploader
    {
        public async Task<string> UploadImage(IFormFile file)
        {
            string newFileName = "";
            if (file != null)
            {
                if (file.Length > 0)
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(file.FileName);

                    //Assigning Unique Filename (Guid)
                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                    //Getting file Extension
                    var fileExtension = Path.GetExtension(fileName);

                    // concatenating  FileName + FileExtension
                    newFileName = String.Concat(myUniqueFileName, fileExtension);

                    // Combines two strings into a path.
                    var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")).Root + $@"\{newFileName}";

                    using (FileStream fs = File.Create(filepath))
                    {
                        await file.CopyToAsync(fs);
                        fs.Flush();
                    }
                }
                else return null!;

                return newFileName;
            }
            else return null!;
        }
    }
}
