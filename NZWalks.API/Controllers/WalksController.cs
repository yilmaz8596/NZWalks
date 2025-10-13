using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repositories;

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
        public async Task<IActionResult> CreateWalk([FromBody] AddWalkRequestDTO addWalkRequestDTO)
        {
            // Map DTO to Domain Model 
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDTO);
            await walkrepository.CreateAsync(walkDomainModel);

            // Map domain model to DTO 
            return Ok(mapper.Map<WalkDTO>(walkDomainModel));
        }

        [HttpGet]
        public async Task<IActionResult> GetWalks()
        {
            var walksDomainModel = await walkrepository.GetAllAsync();
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
