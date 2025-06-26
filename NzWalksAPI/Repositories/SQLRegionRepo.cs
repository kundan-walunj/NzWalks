using Microsoft.EntityFrameworkCore;
using NzWalksAPI.Data;
using NzWalksAPI.Models.Domain;

namespace NzWalksAPI.Repositories
{
    public class SQLRegionRepo : IRegionRepo
    {   
        //di using constructor
        public readonly WalkDbContext walkDbContext;
        public SQLRegionRepo(WalkDbContext db) { 
           walkDbContext = db;  
        }

        public async Task<Regions?> CreateRegionAsy(Regions regions)
        {
            await walkDbContext.AddAsync(regions);
            await walkDbContext.SaveChangesAsync();
            return regions;
        }

        public async Task<Regions?> DeleteRegionAsy(Guid id)
        {
            var region= await walkDbContext.RegionSet.FirstOrDefaultAsync(x=>x.Id==id);
            if (region == null) { return null; }
            walkDbContext.RegionSet.Remove(region);
            await walkDbContext.SaveChangesAsync(); 
            return region;
        }

        public async Task<List<Regions>> GetAllRegionsAsy()
        {
           return await walkDbContext.RegionSet.ToListAsync();  
        }

        public async Task<Regions?> GetSingleRegionAsy(Guid id)
        {
            return await walkDbContext.RegionSet.FirstOrDefaultAsync(x=>x.Id==id);   
        }

        public async Task<Regions?> UpdateRegionsAsy(Guid id, Regions region)
        {
            var regiondomainmodel = await walkDbContext.RegionSet.FirstOrDefaultAsync(x => x.Id == id);
            if (regiondomainmodel == null)
            {
                return null;
            }
            //update values
            regiondomainmodel.Name = region.Name;
            regiondomainmodel.Code = region.Code;
            regiondomainmodel.RegionImageUrl = region.RegionImageUrl;
            await walkDbContext.SaveChangesAsync();
            return regiondomainmodel;
        }
    }
}
