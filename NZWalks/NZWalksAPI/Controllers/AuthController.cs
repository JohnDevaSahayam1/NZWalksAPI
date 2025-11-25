using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.DTO.Login;
using NZWalksAPI.Models.DTO.Register;
using NZWalksAPI.Repositories.IRepository;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        // POST: api/Auth/Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            if (registerRequestDTO == null)
                return BadRequest("Invalid request data.");

            var identityUser = new IdentityUser
            {
                UserName = registerRequestDTO.Username,
                Email = registerRequestDTO.Username
            };

            var result = await userManager.CreateAsync(identityUser, registerRequestDTO.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            // Add roles 
            if (registerRequestDTO.Roles != null && registerRequestDTO.Roles.Any())
            {
                var roleResult = await userManager.AddToRolesAsync(identityUser, registerRequestDTO.Roles);
                if (!roleResult.Succeeded)
                    return BadRequest(roleResult.Errors);
            }

            return Ok("User registered successfully! Please login.");
        }



        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var user = await userManager.FindByNameAsync(loginRequestDTO.Username);
            if (user == null)
                return Unauthorized("Invalid username or password.");

            var isPasswordValid = await userManager.CheckPasswordAsync(user, loginRequestDTO.Password);
            if (!isPasswordValid)
                return Unauthorized("Invalid username or password.");

            var roles = await userManager.GetRolesAsync(user);
            if (!roles.Any())
                return Unauthorized("User has no roles assigned.");

            // Generate JWT token
            var token = tokenRepository.CreateJwtToken(user, roles.ToList());

            var response = new LoginResponseDTO
            {
                Message = "Login successful!",
                Token = token
                //Username = user.UserName,
                //Roles = roles
            };
            return Ok(response);
        }


    }
}
