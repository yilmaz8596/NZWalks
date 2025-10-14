using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.DTO;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repositories;
using NZWalks.API.CustomActionFilters;
using AutoMapper;

namespace NZWalks.API.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {

        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

    public RegionsController(AppDbContext dbContext, IRegionRepository regionRepository, 
        IMapper mapper)
    {
        this.regionRepository = regionRepository;
        this.mapper = mapper;
    }
    [HttpGet]
        public async Task<IActionResult> GetAll()
        {
        // Get data from database - Regions table
        var regions = await regionRepository.GetAllAsync();

        if (regions == null || !regions.Any())
        {
            return NotFound();
        }


        return Ok(mapper.Map<List<RegionDTO>>(regions));
        }

         [HttpGet]
         [Route("{id:Guid}")]

    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var region = await regionRepository.GetByIdAsync(id);

        if (region == null)
        {
            return NotFound();
        }


        return Ok(mapper.Map<RegionDTO>(region));
    }

    [HttpPost]
    [ValidateModel]
    public async Task<IActionResult> CreateRegion([FromBody] AddRegionRequestDTO addRegionRequestDTO)
    {
            // Map or convert DTO to Domain model 
            var regionDomainModel = mapper.Map<Region>(addRegionRequestDTO);

            // Use domain model to create region in database
            regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);


            // Map domain model back to DTO
            var regionDTO = mapper.Map<RegionDTO>(regionDomainModel);

        return CreatedAtAction(nameof(GetById), new { id = regionDTO.Id }, regionDTO);
      
    }

    [HttpPut]
    [ValidateModel]
    [Route("{id:Guid}")]

    public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO updateRegionRequestDTO)
    {
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDTO);

            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }



            // Map domain model back to DTO 
            var regionDTO = mapper.Map<RegionDTO>(regionDomainModel);

            return Ok(regionDTO);
        

    }

    [HttpDelete]
    [Route("{id:Guid}")] 

    public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
    {  
        var regionDomainModel = await regionRepository.DeleteAsync(id);

        if (regionDomainModel == null) {
            return NotFound();
        }

        var regionDTO = mapper.Map<RegionDTO>(regionDomainModel);



        return Ok(regionDTO);
    }
}

