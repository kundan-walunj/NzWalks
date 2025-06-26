using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NzWalksAPI.Data
{
    public class WalksAuthDbContext : IdentityDbContext

    {
        public WalksAuthDbContext(DbContextOptions<WalksAuthDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var ReadRoleId = "083483e2-e364-490f-bdee-3399c4409021";
            var WriteRoleId = "13a6ea96-4ced-4bf9-9034-a7dedc75ea78";
            var roles = new List<IdentityRole>() {
             new IdentityRole
             {
                 Id = ReadRoleId,
                 ConcurrencyStamp=ReadRoleId,
                 Name="Reader",
                 NormalizedName="Reader".ToUpper()

             },
              new IdentityRole
             {
                 Id = WriteRoleId,
                 ConcurrencyStamp=WriteRoleId,
                 Name="Writer",
                 NormalizedName="Writer".ToUpper()

             }


            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
