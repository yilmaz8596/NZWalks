using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.DTO;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {

     private readonly AppDbContext dbContext;

    public RegionsController(AppDbContext dbContext)
    {
         this.dbContext = dbContext;
    }
    [HttpGet]
        public IActionResult GetAll()
        {
        // Get data from database - Regions table
        var regions = dbContext.Regions.ToList();

        if (regions == null || !regions.Any())
        {
            return NotFound();
        }

        // We need to map the region domain model to DTO
        var regionsDTO = new List<RegionDTO>();
        foreach (var region in regions)
        {
            var regionDTO = new RegionDTO
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                RegionImageUrl = region.RegionImageUrl
            };
            regionsDTO.Add(regionDTO);
        }
        return Ok(regions);
        }

         [HttpGet]
         [Route("{id:Guid}")]

    public IActionResult GetById([FromRoute] Guid id)
    {
        var region = dbContext.Regions.FirstOrDefault(x => x.Id == id);

       if (region == null)
        {
            return NotFound();
        }

        var regionDTO = new RegionDTO
        {
            Id = region.Id,
            Name = region.Name,
            Code = region.Code,
            RegionImageUrl = region.RegionImageUrl
        };

        return Ok(regionDTO);
    }

    [HttpPost]
    public IActionResult CreateRegion([FromBody] AddRegionRequestDTO addRegionRequestDTO)
    {
        // Map or convert DTO to Domain model 
        var regionDomainModel = new Region
        {
            Code = addRegionRequestDTO.Code,
            Name = addRegionRequestDTO.Name,
            RegionImageUrl = addRegionRequestDTO.RegionImageUrl,

        };

        // Use domain model to create region in database
        dbContext.Regions.Add(regionDomainModel);

        dbContext.SaveChanges();

        // Map domain model back to DTO
        var regionDTO = new RegionDTO
        {
            Id = regionDomainModel.Id,
            Code = regionDomainModel.Code,
            Name = regionDomainModel.Name,
            RegionImageUrl = regionDomainModel.RegionImageUrl
        };

        return CreatedAtAction(nameof(GetById), new { id = regionDTO.Id }, regionDTO);
    }

    [HttpPut]
    [Route("{id:Guid}")]

    public IActionResult UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO updateRegionRequestDTO)
    {
        var regionDomainModel = dbContext.Regions.FirstOrDefault(x => x.Id == id);

        if (regionDomainModel == null)
        {
            return NotFound();
        }

        // Map or convert DTO to Domain model 
        regionDomainModel.Code = updateRegionRequestDTO.Code; 
        regionDomainModel.Name = updateRegionRequestDTO.Name;   
        regionDomainModel.RegionImageUrl = updateRegionRequestDTO.RegionImageUrl;

        dbContext.SaveChanges();

        // Map domain model back to DTO 
        var regionDTO = new RegionDTO
        {
            Id = regionDomainModel.Id,
            Code = regionDomainModel.Code,
            Name = regionDomainModel.Name,
            RegionImageUrl = regionDomainModel.RegionImageUrl
        }; 

        return Ok(regionDTO);
    }

    [HttpDelete]
    [Route("{id:Guid}")] 

    public IActionResult DeleteRegion([FromRoute] Guid id)
    {
        var regionDomainModel = dbContext.Regions.FirstOrDefault(x => x.Id == id); 

        if (regionDomainModel == null)
        {
            return NotFound();
        } 

        dbContext.Remove(regionDomainModel); 
        dbContext.SaveChanges();

        return Ok();
    }
}

