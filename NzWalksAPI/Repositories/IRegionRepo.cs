using NzWalksAPI.Models.Domain;

namespace NzWalksAPI.Repositories
{
    public interface IRegionRepo
    {
         Task<List<Regions>> GetAllRegionsAsy();  //declare
        Task<Regions?> GetSingleRegionAsy(Guid id);
        Task<Regions?> CreateRegionAsy(Regions regions);

        Task<Regions?> UpdateRegionsAsy(Guid id,Regions regions);

        Task<Regions?> DeleteRegionAsy(Guid id);
    }
}
