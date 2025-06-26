using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NzWalksAPI.Data;
using NzWalksAPI.Models.Domain;
using NzWalksAPI.Models.DTO;
using NzWalksAPI.Repositories;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace NzWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RegionController : ControllerBase
    {
        public readonly WalkDbContext walkDbContext;

        public readonly IRegionRepo RegionRepo;
        private readonly ILogger<RegionController> logger;

        public RegionController(WalkDbContext dbContext,IRegionRepo regionRepo,ILogger<RegionController> logger1)
        {

            walkDbContext = dbContext;
            RegionRepo = regionRepo;
            logger = logger1;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            
            //get data from database -domain model
            var regiondomainmodel =await RegionRepo.GetAllRegionsAsy();

            logger.LogInformation($"get regions:{JsonSerializer.Serialize(regiondomainmodel)}");
            //throw new Exception("new exp");
            //map model to dto

            var regiondto = new List<RegionDto>();
            foreach (var region in regiondomainmodel)
            {
                regiondto.Add(new RegionDto()

                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl
                });


            }

            //return dto EXPOSING DTO INSTEAD OF DOMAIN MODEL
            return Ok(regiondto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetSingleRegion([FromRoute] Guid id)
        {
            var regiondomailmodel =await RegionRepo.GetSingleRegionAsy(id);
            if (regiondomailmodel == null)
            {
                return NotFound();
            }
            var regiondto = new RegionDto();
            regiondto.Id = regiondomailmodel.Id;
            regiondto.Code = regiondomailmodel.Code;
            regiondto.Name = regiondomailmodel.Name;
            regiondto.RegionImageUrl = regiondomailmodel.RegionImageUrl;

            return Ok(regiondto);

        }

        [HttpPost]

        public async Task<IActionResult> CreateRegion([FromBody] CreateNewRegion newregion)
        //newregion contains data
        {
            if (ModelState.IsValid)
            {


                //get dto by user
                //convert dto to domain model
                var regionDomainmodel = new Regions
                {
                    Name = newregion.Name,
                    RegionImageUrl = newregion.RegionImageUrl,
                    Code = newregion.Code,


                };
                //add to db
                regionDomainmodel = await RegionRepo.CreateRegionAsy(regionDomainmodel);
                //convert domain model to dto for display

                var regiondto = new RegionDto
                {
                    Id = regionDomainmodel.Id,
                    Name = regionDomainmodel.Name,
                    Code = newregion.Code,
                    RegionImageUrl = newregion.RegionImageUrl
                };

                //201  response
                return CreatedAtAction(nameof(GetSingleRegion), new { id = regionDomainmodel.Id }, regiondto);
            }
            else { 
              return BadRequest(ModelState);
            }
        }

        //update data

        [HttpPut]
        [Route("{id:guid}")]
        //THIS METHOD NEEDS A ID AND REQ DATA
        //before displaying convert data to dto and sending data to db(repo) convert it to normal obj
        public async Task<IActionResult> UpdateRegions([FromRoute] Guid id, [FromBody] UpdateRegion region)
        {
            if (ModelState.IsValid)
            {
                //dto to domain model
                var regiondomainmodel = new Regions
                {
                    Name = region.Name,
                    Code = region.Code,
                    RegionImageUrl = region.RegionImageUrl,

                };

                //find id in database
                regiondomainmodel = await RegionRepo.UpdateRegionsAsy(id, regiondomainmodel);
                if (regiondomainmodel == null)
                {
                    return NotFound();
                }
                //convert domain model to dto
                var DisplayDto = new RegionDto
                {
                    Id = regiondomainmodel.Id,
                    Name = regiondomainmodel.Name,
                    Code = regiondomainmodel.Code,
                    RegionImageUrl = regiondomainmodel.RegionImageUrl
                };
                return Ok(DisplayDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        //delete a item
        [HttpDelete]
        [Route("{id:guid}")]
       // [Authorize(Roles ="Writer")]
        public async Task<IActionResult> DeleteRegions([FromRoute] Guid id)
        {
            var regiondata=await RegionRepo.DeleteRegionAsy(id);
            if (regiondata == null) { return NotFound(); }
            var regionDto = new RegionDto
            {
                Id=regiondata.Id,
                Name = regiondata.Name,
                Code = regiondata.Code,
                RegionImageUrl = regiondata.RegionImageUrl
            };
            return Ok(regionDto);

        }



    }
}
