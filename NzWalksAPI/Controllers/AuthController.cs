using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NzWalksAPI.Models.DTO;
using NzWalksAPI.Repositories;

namespace NzWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ItokenRepo itokenRepo;

        public AuthController(UserManager<IdentityUser> userManager,ItokenRepo itokenRepo) {
            this.userManager = userManager;
            this.itokenRepo = itokenRepo;
        }    
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] AuthDto authDto)
        {
            var User = new IdentityUser
            {
                UserName = authDto.Username,
                Email = authDto.Username,
            };
            var CreateUser=await userManager.CreateAsync(User,authDto.Password);
            if (CreateUser.Succeeded) {
                if (authDto.Roles != null && authDto.Roles.Any())
                {
                    CreateUser = await userManager.AddToRolesAsync(User,authDto.Roles);
                    if (CreateUser.Succeeded) { 
                    return Ok("Created");
                    }
                }
            }
            return BadRequest("not created");
        }
        //CREATE LOGIN TO ASSIGN JWT
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] Logindto logindto) {
          var user=  await userManager.FindByEmailAsync(logindto.Username);
            if (user != null) { 
              var checkPassword=await userManager.CheckPasswordAsync(user, logindto.Password);
                //create token
                
                    if (checkPassword) {

                        var role = await userManager.GetRolesAsync(user);
                    if (role != null)
                    {

                        var jwttoken =itokenRepo.GetToken(user, role.ToList());


                        return Ok(jwttoken);
                    }
                }
                }
            
            return BadRequest("invalid user");
        
        }


    }
}
