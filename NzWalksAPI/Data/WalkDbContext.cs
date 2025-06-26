using Microsoft.EntityFrameworkCore;
using NzWalksAPI.Models.Domain;

namespace NzWalksAPI.Data
{
    public class WalkDbContext: DbContext //Entity Framework Core’s main class to interact with a database
    {
       public WalkDbContext(DbContextOptions<WalkDbContext> dbContextOptions):base(dbContextOptions) //allows EF Core to use the options
      //(like the SQL Server provider and connection string) to configure how the context connects to the database.

        {

        }

       public DbSet<Difficulty> DifficultySet { get; set; }  
       public DbSet<Regions> RegionSet { get; set; }  
       public DbSet<Walks> Walks { get; set; }
        public DbSet<Image> Images { get; set; }

        //seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var Difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id=Guid.Parse("896a2fc8-5b65-4b2a-9468-5643993e148a"),
                    Name="Hard "
                },
                 new Difficulty()
                {
                    Id=Guid.Parse("3b91e7a1-6ac6-4b5f-801f-cbfb4351e43b"),
                    Name="Medium "
                },
                 new Difficulty()
                {
                      Id=Guid.Parse("44aaaa35-f8a5-452d-b10c-a1a753ec6359"),
                      Name="Easy "
                }
            };
            //SEED MODEL TO DB
            modelBuilder.Entity<Difficulty>().HasData(Difficulties);

            var regions = new List<Regions>
            {
                new Regions
                {
                    Id = Guid.Parse("01f5d410-6cdb-49f4-959e-44a18c387b51"),
                    Name = "Aucklan",
                    Code = "AKL",
                    RegionImageUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Regions
                {
                    Id = Guid.Parse("f689fd5b-1bb4-4319-bd71-26f4a42cb057"),
                    Name = "Northlan",
                    Code = "NTL",
                    RegionImageUrl = null
                },
                new Regions
                {
                    Id = Guid.Parse("a5d43070-2af0-4f07-8622-8d6c69f3f4e0"),
                    Name = "Bay Of Plent",
                    Code = "BOP",
                    RegionImageUrl = null
                },
                new Regions
                {
                    Id = Guid.Parse("4eb24ed8-4dbd-43ad-9cf4-12d0ec4e70a3"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = null
                },

            };

            modelBuilder.Entity<Regions>().HasData(regions);
           
        }

    }


}
