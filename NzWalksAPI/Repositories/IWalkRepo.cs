using NzWalksAPI.Models.Domain;

namespace NzWalksAPI.Repositories
{
    public interface IWalkRepo
    {
        Task<Walks?> AddWalkAsyc(Walks walks);

        Task<List<Walks>> GetWalkAsyc(string? filterOn = null, string? filterQuery = null, string? sortBy =null,bool isAscending=true,int pageno=1,int pagesize=1000);
        
    }
}
