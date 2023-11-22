using MarienProject.Api.Repositories.Contracts;
using MarienProject.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarienProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register([FromBody] UserRegisterRequestDto request)
        {
            var result = await _userRepository.RegisterUser(request);

            if (result)
            {
                return Ok(new { Message = "User registered successfully" });
            }
            else
            {
                return BadRequest(new { Message = "Registration failed" });
            }
        }
    }
}