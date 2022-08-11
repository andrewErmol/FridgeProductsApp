using AutoMapper;
using FridgeProductsApp.Domain.Models;
using FridgeProductsApp.Contracts;
using FridgeProductsApp.Contracts.IRepositories;
using FridgeProductsApp.Domain.DTO.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FridgeProductsApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAuthenticationManagerRepository _authManager;

        public AuthenticationController (ILoggerManager logger, 
            IMapper mapper, 
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager, 
            IAuthenticationManagerRepository authManager)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _authManager = authManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _authManager.ValidateUser(user))
            {
                _logger.LogWarn($"{nameof(Authenticate)}: Authentication failed. Wrong user name or password.");
                return Unauthorized();
            }

            return Ok(new { Token = await _authManager.CreateToken() });
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            var user = _mapper.Map<User>(userForRegistration);

            foreach(string roleName in userForRegistration.Roles)
            {
                if (! await _roleManager.RoleExistsAsync(roleName))
                {
                    _logger.LogError("This role or roles doesn't exist.");
                    return BadRequest("Entered role(s) doesn't exist");
                }
            }

            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            await _userManager.AddToRolesAsync(user, userForRegistration.Roles);

            return StatusCode(201);
            
        }
    }
}
