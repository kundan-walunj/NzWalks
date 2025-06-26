using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NzWalksAPI.Data;
using NzWalksAPI.Models.Domain;
using NzWalksAPI.Models.DTO;
using NzWalksAPI.Repositories;
using System.Linq.Expressions;
using System.Net;

namespace NzWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        public readonly WalkDbContext WalkDbContext;
        private readonly IWalkRepo walkRepo;

        public WalksController(WalkDbContext walkDbContext,IWalkRepo walkRepo) {
            WalkDbContext = walkDbContext;
            this.walkRepo = walkRepo;
        }

        [HttpPost]
     public async Task<IActionResult> AddWalk([FromBody] CreateNewWalks newWalks)
        {
            //recives dto
            var convertWalksdto = new Walks
            {
                Name = newWalks.Name,
                Description = newWalks.Description, 
                LengthInKm = newWalks.LengthInKm,
                WalkImageUrl = newWalks.WalkImageUrl,
                RegionId = newWalks.RegionId,
                DifficultyId = newWalks.DifficultyId
                
            };
            convertWalksdto= await walkRepo.AddWalkAsyc(convertWalksdto);

            //convert to dto to display
            var Walkstodto = new CreateNewWalks
            {
                Name = convertWalksdto.Name,
                Description = convertWalksdto.Description,
                LengthInKm = convertWalksdto.LengthInKm,
                WalkImageUrl = convertWalksdto.WalkImageUrl,
                RegionId = convertWalksdto.RegionId,
               DifficultyId = convertWalksdto.DifficultyId
            };

            return Ok(Walkstodto);
        }
        //applying filter
        //Get:api/walks?filterOn=Name&filterQuery=Track&sortBy=Name&isAsending=true

        [HttpGet]

        public async Task<IActionResult> GetWalk([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? sortBy, [FromQuery] bool isAscending,
            [FromQuery] int pageno = 1, int pageesize = 1000)
        {
            try
            {
                //throw new Exception("yea");
                var Walkdomainmodel = await walkRepo.GetWalkAsyc(filterOn, filterQuery, sortBy, isAscending = true, pageno, pageesize);
                //convert to dto
                var Walkdto = new List<WalksDto>();
                foreach (var Walk in Walkdomainmodel)
                {
                    Walkdto.Add(new WalksDto
                    {
                        Name = Walk.Name,
                        Description = Walk.Description,
                        LengthInKm = Walk.LengthInKm,
                        WalkImageUrl = Walk.WalkImageUrl,
                        RegionId = Walk.RegionId,
                        DifficultyId = Walk.DifficultyId
                    });
                }
                return Ok(Walkdto);
            }
            catch (Exception ex) {
                return Problem("internal error", null, (int)HttpStatusCode.InternalServerError);
            
            }
            
         
            
            
        }

    }
}
