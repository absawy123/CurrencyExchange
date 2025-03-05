using CurrencyExchange.Application.Dtos;
using CurrencyExchange.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyExchange.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;

        public AccountController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager)
        {
         
            _userManager = userManager;
            _signinManager = signInManager;

        }

        [HttpPost("Registure")]
        public async Task<ActionResult> Registure([FromBody] RegistureDto registureDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var newUser = new ApplicationUser()
            { Email = registureDto.Email,
            UserName = registureDto.UserName
            };
            var result = await _userManager.CreateAsync(newUser, registureDto.Password);
            if (result.Succeeded)
                return Ok("User registured successfully");

            return BadRequest(result.Errors);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user =await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
                return Unauthorized();

            var result = await _signinManager.CheckPasswordSignInAsync(user, loginDto.Password,false);
            if (result.Succeeded) 
                return Ok();

            return Unauthorized();


        }


    }
}
