using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalksAPI.CustomActionFilter;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO.Region;
using NZWalksAPI.Repositories.IRepository;
using NZWalksAPI.Repositories.Repository;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalkDbContext _dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NZWalkDbContext dbContext,IRegionRepository regionRepository,IMapper mapper)
        {
            _dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        // GET: api/Regions/GetAllRegions
        [HttpGet("GetAllRegions")]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery)
        {
            var regions = await regionRepository.GetAllRegionsAsync(filterOn, filterQuery);

            var regionDtos = mapper.Map<List<Regiondto>>(regions);

            return Ok(regionDtos);
        }



        // GET: api/Regions/GetRegionById/{id}
        [HttpGet("GetRegionById/{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var regionDomain = await regionRepository.GetRegionByIdAsync(id);

            if (regionDomain == null)
                return NotFound();

            //var regionDto = new Regiondto
            //{
            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,
            //    RegionImageUrl = regionDomain.RegionImageUrl
            //};
          var regionDto= mapper.Map<Regiondto>(regionDomain);
            return Ok(regionDto);
        }


        // POST: api/Regions/CreateRegion
        [HttpPost("CreateRegion")]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestdto addRegionRequestdto)
        {
            //var regionDomain = new Region
            //{
            //    Code = addRegionRequestdto.Code,
            //    Name = addRegionRequestdto.Name,
            //    RegionImageUrl = addRegionRequestdto.RegionImageUrl
            //};
            var regionDomain =  mapper.Map<Region>(addRegionRequestdto);

            await regionRepository.CreateRegionAsync(regionDomain);

            //var regionDto = new Regiondto
            //{
            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,
            //    RegionImageUrl = regionDomain.RegionImageUrl
            //};
            var regionDto= mapper.Map<Regiondto>(regionDomain);
            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }


        // PUT: api/Regions/UpdateRegion/{id}
        [HttpPut("UpdateRegion/{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestdto updateRegionRequestdto)
        {
            //var regionDomain = new Region
            //{
            //    Code = updateRegionRequestdto.Code,
            //    Name = updateRegionRequestdto.Name,
            //    RegionImageUrl = updateRegionRequestdto.RegionImageUrl
            //};
            var regionDomain = mapper.Map<Region>(updateRegionRequestdto);
            // CALL REPOSITORY 
            var updatedRegion = await regionRepository.UpdateRegionAsync(id, regionDomain);

            if (updatedRegion == null)
                return NotFound();   

            // convert domain back to DTO
            //var regionDto = new Regiondto
            //{
            //    Id = updatedRegion.Id,
            //    Code = updatedRegion.Code,
            //    Name = updatedRegion.Name,
            //    RegionImageUrl = updatedRegion.RegionImageUrl
            //};
            var regionDto= mapper.Map<Regiondto>(updatedRegion);

            return Ok(regionDto);
        }


        // DELETE: api/Regions/DeleteRegion/{id}
        [HttpDelete("DeleteRegion/{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomain = await regionRepository.DeleteRegionAsync(id);
            if (regionDomain == null)
                return NotFound();

            //var regionDto = new Regiondto
            //{
            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,
            //    RegionImageUrl = regionDomain.RegionImageUrl
            //};
            var regionDto=mapper.Map<Regiondto>(regionDomain);

            return Ok(regionDto);

        }
    }
}
