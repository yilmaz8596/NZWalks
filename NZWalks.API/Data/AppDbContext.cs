using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;


namespace NZWalks.API.Data;
    public class AppDbContext(DbContextOptions<AppDbContext> options):DbContext(options)
    {
     public DbSet<Difficulty> Difficulties { get; set; } 
    public DbSet<Region> Regions { get; set; }
    public DbSet<Walk> Walks { get; set; }
    public DbSet<Image> Images { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            base.OnModelCreating(modelBuilder);
           // Seed Data 

        var difficulties = new List<Difficulty>()
        {
            new Difficulty()
            {
                Id = Guid.Parse("fe2b3f5e-1d3c-4d3b-9c3a-1f2e3d4c5b6a"),
                Name = "Easy"
            },
            new Difficulty()
            {
                Id = Guid.Parse("ae2b3f5e-1d3c-4d3b-9c3a-1f2e3d4c5b6b"),
                Name = "Medium"
            },
            new Difficulty()
            {
                Id = Guid.Parse("be2b3f5e-1d3c-4d3b-9c3a-1f2e3d4c5b6c"),
                Name = "Hard"
            }
        };

        // Seed the difficulties data
        modelBuilder.Entity<Difficulty>().HasData(difficulties);

        var regions = new List<Region>()
        {
            new Region() {
                Id = Guid.Parse("12345678-1234-1234-1234-123456789abc"),
                Name = "Auckland",
                Code = "AKL",
                RegionImageUrl = "https://www.earthtrekkers.com/wp-content/uploads/2023/10/Auckland-Itinerary.jpg.optimal.jpg"
            },
            new Region() {
                Id = Guid.Parse("22345678-1234-1234-1234-123456789def"),
                Name = "Wellington",
                Code = "WLG",
                RegionImageUrl = "https://res.klook.com/image/upload/fl_lossy.progressive,q_60/Mobile/City/yed8yyqbpif5ysgqg88m.jpg"
            },
            new Region() {
                Id = Guid.Parse("32345678-1234-1234-1234-123456789012"),
                Name = "Christchurch",
                Code = "CHC",
                RegionImageUrl = "https://www.lovoirbeauty.com/wp-content/uploads/2023/07/1-3.png"
            }

        };
            modelBuilder.Entity<Region>().HasData(regions);
    }
    }

