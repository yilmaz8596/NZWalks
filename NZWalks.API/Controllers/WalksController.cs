using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repositories;
using NZWalks.API.CustomActionFilters;

namespace NZWalks.API.Controllers
{
    // api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkrepository;
        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;   
            this.walkrepository = walkRepository;
        }
        [HttpPost] 
        [ValidateModel]
        public async Task<IActionResult> CreateWalk([FromBody] AddWalkRequestDTO addWalkRequestDTO)
        {
            // Map DTO to Domain Model 
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDTO);
            await walkrepository.CreateAsync(walkDomainModel);

            // Map domain model to DTO 
            return Ok(mapper.Map<WalkDTO>(walkDomainModel));
        }

        [HttpGet]
        // GET: /api/walks?filterOn=Name?filterQuery=track&sortBy=Name&isAscending=true
        public async Task<IActionResult> GetWalks(
            [FromQuery] string? filterOn, 
            [FromQuery] string? filterQuery,
            [FromQuery] bool? isAscending,
            [FromQuery] string? sortBy = null,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 1000
            )
        {
            var walksDomainModel = await walkrepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);
            return Ok(mapper.Map<List<WalkDTO>>(walksDomainModel));
        }

        [HttpGet]
        [Route("{id:guid}")] 

        public async Task<IActionResult> GetWalkById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkrepository.GetByIdAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDTO>(walkDomainModel));
        }

        [HttpPut]
        [ValidateModel]
        [Route("{id:guid}")] 

        public async Task<IActionResult> UpdateWalkById([FromRoute] Guid id, UpdateWalkRequestDTO updateWalkRequestDTO) { 

            var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDTO);
            walkDomainModel = await walkrepository.UpdateAsync(id, walkDomainModel);
            if (walkDomainModel == null) 
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDTO>(walkDomainModel));
        }
        [HttpDelete]
        [Route(("{id:guid}"))]

        public async Task<IActionResult> DeleteWalkById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkrepository.GetByIdAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            // Deletion logic would go here (not implemented in the repository interface)
            return NoContent();
        }
    }
}
