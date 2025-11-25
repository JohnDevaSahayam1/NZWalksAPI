using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.CustomActionFilter;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO.Walk;
using NZWalksAPI.Repositories.IRepository;
using System.Reflection.Metadata.Ecma335;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }


        // POST: api/Walks/CreateWalk
        [HttpPost("CreateWalk")]
        [ValidateModel]
        public async Task<IActionResult> CreateWalk([FromBody] AddWalkRequestDTO addWalkRequestDTO)
        {
            var walkDomain = mapper.Map<Walk>(addWalkRequestDTO);
            var Walk = await walkRepository.CreateWalkAsync(walkDomain);
            var walkDTO = mapper.Map<WalkDTO>(Walk);
            return Ok(walkDTO);
        }

        //GET:api/Walks/GetAllWalks
        [HttpGet("GetAllWalks")]
        public async Task<IActionResult> GetAllWalk([FromQuery] string? FilterOn, [FromQuery] String? FilerQuery, [FromQuery] String? SortBy, [FromQuery] bool? isAscending, [FromQuery]int pageNumber=1, [FromQuery] int pageSize=1000)
        {
            var Walks = await walkRepository.GetAllWalksAsync(FilterOn, FilerQuery, SortBy, isAscending,pageNumber,pageSize);

            var WalsDTO = mapper.Map<List<WalkDTO>>(Walks);
            return Ok(WalsDTO);
        }

        //GET:api/Walks/GetWalkById/{id}
        [HttpGet("GetWalkById/{id:guid}")]
        public async Task<IActionResult> GetWalkById([FromRoute] Guid id)
        {
            var Walk = await walkRepository.GetWalkById(id);
            if (Walk == null)
            {
                return NotFound();
            }
            var WalkDTO = mapper.Map<WalkDTO>(Walk);
            return Ok(WalkDTO);

        }

        //PUT: api/Walks/UpdateWalkById/{id}
        [HttpPut("UpdateWalkById/{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateWalkById([FromRoute] Guid id, [FromBody] UpdateWalkRequestDTO updateWalkRequestDTO)
        {
            var walkDomain = mapper.Map<Walk>(updateWalkRequestDTO);
            var updatedWalk = await walkRepository.UpdateWalkById(id, walkDomain);
            if (updatedWalk == null)
            {
                return NotFound();
            }
            var updatedWalkDTO = mapper.Map<WalkDTO>(updatedWalk);
            return Ok(updatedWalkDTO);
        }

        //DELETE: api/Walks/DeleteWalkById/{id}
        [HttpDelete("DeleteWalkById/{id:guid}")]
        public async Task<IActionResult> DeleteWalkById([FromRoute] Guid id)
        {
            var Walk = await walkRepository.DeleteWalkById(id);
            if(Walk == null)
            {
                return NotFound();
            }

            var Walkdto = mapper.Map<WalkDTO>(Walk);
            return Ok(Walkdto);
        }
    }
}
