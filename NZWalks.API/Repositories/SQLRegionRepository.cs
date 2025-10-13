using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories;
public class SQLRegionRepository(AppDbContext appDbContext) : IRegionRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;


    public async Task<List<Region>> GetAllAsync()
    {
        return await _appDbContext.Regions.ToListAsync();
    }

    public async Task<Region> GetByIdAsync(Guid id)
    {
        return await _appDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
    }

   public async Task<Region?> CreateAsync(Region region)
    {
        await _appDbContext.Regions.AddAsync(region);
        await _appDbContext.SaveChangesAsync();
        return region;
    }

    public async Task<Region?> UpdateAsync(Guid id, Region region)
    {
         var existingRegion = await _appDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        if (existingRegion == null)
        {
            return null;
        }
        existingRegion.Name = region.Name;
        existingRegion.Code = region.Code;
        existingRegion.RegionImageUrl = region.RegionImageUrl;
        await _appDbContext.SaveChangesAsync();
        return existingRegion;
    }

    public async Task<Region?> DeleteAsync(Guid id)
    {
        var existingRegion = await _appDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        if (existingRegion == null)
        {
            return null;
        }
        _appDbContext.Regions.Remove(existingRegion);
        await _appDbContext.SaveChangesAsync();
        return existingRegion;
    }
}

