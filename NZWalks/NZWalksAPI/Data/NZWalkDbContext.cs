using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Data
{
    public class NZWalkDbContext : DbContext
    {
        public NZWalkDbContext(DbContextOptions<NZWalkDbContext> options) : base(options)
        {

        }
        public DbSet<Difficulty> difficulties { get; set; }
        public DbSet<Region> regions { get; set; }
        public DbSet<Walk> walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //seed data to the Difficulty table
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("7c5d53ce-37c8-46e4-a407-57b51c5dc119"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("e28d526e-8129-4cab-a0ac-14d18c0e048f"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("7534ec97-b24d-4860-b620-5fbd816069fa"),
                    Name = "Hard"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            //seed data to the Region table
            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("f8592128-1bf1-4f12-8f54-61d3f7f43f34"),
                    Code = "AKL",
                    Name = "Auckland",
                    RegionImageUrl = null
                },
                new Region()
                {
                    Id = Guid.Parse("4590b8cc-d107-4ac9-b2ce-45180e0d1017"),
                    Code = "WLG",
                    Name = "Wellington",
                    RegionImageUrl = null
                },
                new Region()
                {
                    Id = Guid.Parse("21630836-6b4b-489e-889f-a3a2d676c929"),
                    Code = "CHC",
                    Name = "Christchurch",
                    RegionImageUrl = null
                },
                new Region()
                {
                    Id = Guid.Parse("dd765a99-411e-43f1-a9f5-92d249112cce"),
                    Code = "QWE",
                    Name = "Queentown",
                    RegionImageUrl = null
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }

    }
}
