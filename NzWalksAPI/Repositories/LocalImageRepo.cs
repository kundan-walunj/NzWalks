using NzWalksAPI.Data;
using NzWalksAPI.Models.Domain;

namespace NzWalksAPI.Repositories
{
    public class LocalImageRepo : IImageRepo
    {
        private readonly IWebHostEnvironment _webHostEnvironment;   //for local path of application
        private readonly IHttpContextAccessor _httpContextAccessor;   //url access
        private readonly WalkDbContext walkDbContext;

        public LocalImageRepo(IWebHostEnvironment webHostEnvironment,IHttpContextAccessor httpContextAccessor, WalkDbContext walkDbContext)
        {
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
            this.walkDbContext = walkDbContext;
        }
        public async Task<Image> UploadImage(Image img)
        {
            var localFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images",$"{img.FileName}{img.FileExtension}");


            //upload img to local path
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await img.File.CopyToAsync(stream);


            //https://localhost:1234/images/image.jpg

            var urlFilePath = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}/Images/{img.FileName}{img.FileExtension}";
            img.FilePath = urlFilePath;
           await walkDbContext.Images.AddAsync(img);
            await walkDbContext.SaveChangesAsync();

            return img; 

        }
    }
}
