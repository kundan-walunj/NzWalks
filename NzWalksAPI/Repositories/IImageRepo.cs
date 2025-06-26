using NzWalksAPI.Models.Domain;

namespace NzWalksAPI.Repositories
{
    public interface IImageRepo
    {
       Task<Image> UploadImage(Image img);
    }
}
