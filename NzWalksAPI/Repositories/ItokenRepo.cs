using Microsoft.AspNetCore.Identity;

namespace NzWalksAPI.Repositories
{
    public interface ItokenRepo
    {
        public string GetToken(IdentityUser user,List<string> roles);
    }
}
