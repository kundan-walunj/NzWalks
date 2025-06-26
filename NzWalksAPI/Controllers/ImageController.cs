using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NzWalksAPI.Models.Domain;
using NzWalksAPI.Models.DTO;
using NzWalksAPI.Repositories;

namespace NzWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepo imageRepo;

        public ImageController(IImageRepo imageRepo)
        {
            this.imageRepo = imageRepo;
        }
        [HttpPost]
        [Route("Upload")]

        public async Task<IActionResult> Upload([FromForm] UploadImageDto reqimg)
        {   
            ValidateFileUpload(reqimg);
            if (ModelState.IsValid)
            {    //DTO
                var img = new Image
                {
                    File = reqimg.File,
                    FileName = reqimg.FileName,
                    FileDescription = reqimg.FileDescription,
                    FileExtension = Path.GetExtension(reqimg.File.FileName),
                    FileSizeInBytes = reqimg.File.Length
                };
                //GET FROM IMG REPO
                await imageRepo.UploadImage(img);
                return Ok(img);

            }
            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(UploadImageDto uploadImg)
        {
            var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };

            if (!allowedExtensions.Contains(Path.GetExtension(uploadImg.File.FileName)))
            {
                ModelState.AddModelError("file","unsupported file extension");
            }
            if (uploadImg.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "file size is more");
            }
        }
    }
}
