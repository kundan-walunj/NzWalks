using Microsoft.EntityFrameworkCore;
using NzWalksAPI.Data;
using NzWalksAPI.Models.Domain;

namespace NzWalksAPI.Repositories
{
    public class SQLWalksRepo : IWalkRepo
    {
        public SQLWalksRepo(WalkDbContext walkDb)
        {
            WalkDb = walkDb;
        }

        public readonly WalkDbContext WalkDb;

        public async Task<Walks?> AddWalkAsyc(Walks walks)
        {   
            await WalkDb.Walks.AddAsync(walks);
            await WalkDb.SaveChangesAsync();
            return walks;
        }

        public async Task<List<Walks>> GetWalkAsyc(string? filterO = null, string? filterQuery = null,string? sortBy=null,bool isAscending=true, int pageno = 1, int pagesize = 1000)
        {
           var walks= WalkDb.Walks.AsQueryable();

            //filtering
            if (string.IsNullOrWhiteSpace(filterO) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterO.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
            }
            //sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false) { 
              if(sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending? walks.OrderBy(x => x.Name):walks.OrderByDescending(x => x.Name);
                }
            
            }
            //pagination
            int skipItems=(pageno-1)*pagesize;
              

            return await walks.Skip(skipItems).Take(pagesize).ToListAsync();
            
        }
    }
}
