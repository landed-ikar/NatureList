using Microsoft.AspNetCore.Mvc;
using NatureListService.Configurations;
using NatureListService.Models;
using NatureListService.Services;
using System.Security.Claims;

namespace NatureListService.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase {

        public LoginController() {
        }

        // POST api/<LoginList>
        [HttpPost]
        public async Task<ActionResult<string>> Login(
            [FromBody] LoginDTO loginDTO,
            [FromServices] IUserStorageService userStorage,
            [FromServices] ITokenService tokenService) {
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            IUser user = await userStorage.GetUserAsync(loginDTO);
            if(user == null) {
                return Unauthorized();
            }
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, loginDTO.Login!));
            foreach(IRole role in user.Roles)
                claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
            return tokenService.CreateToken(claims);
        }
    }
}
