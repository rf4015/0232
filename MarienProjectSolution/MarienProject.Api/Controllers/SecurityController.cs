using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MarienProject.Api.Services.Contracts;
using System.IdentityModel.Tokens.Jwt;
using MarienProject.Models.Dtos;
using MarienProject.Models.Dtos.JWT;

namespace MarienProject.Api.Controllers
{
	[Route("api/controller")]
	[ApiController]
	public class SecurityController : ControllerBase
	{
		private readonly IAuthorizationService _authorizationServive;

		public SecurityController(IAuthorizationService authorizationServive)
		{
            _authorizationServive = authorizationServive;
		}
		//Get token and refresh token by credential
		
		[HttpPost]
		[Route("login")]
		public async Task<IActionResult> Login([FromBody] UserLoginRequestDto request)
		{
			var result = await _authorizationServive.ReturnToken(request);

			if (result == null)
			{
				return Unauthorized(new { Message = "Invalid credentials" });
			}
            // Si el inicio de sesión es exitoso, puedes generar y devolver un token aquí si lo necesitas
            return Ok(new { Message = "Login successful", AccessToken = result });
		}

		//Get onother refresh token, by another refresh token
		[HttpPost]
		[Route("getRefreshToken")]
		public async Task<IActionResult> GetRefreshToken([FromBody] RefreshTokenRequestDto request)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var isTokenExpired = tokenHandler.ReadJwtToken(request.TokenExpired);

			if (isTokenExpired.ValidTo > DateTime.UtcNow) return BadRequest(new AuthorizationResponseDto { Result = false, Msg = "Token hasn't expired yet" });

			//Gettingn token' id
			string userId = isTokenExpired.Claims.First(i =>
					i.Type == JwtRegisteredClaimNames.NameId).Value.ToString();

			var authorizationResponse = await _authorizationServive.ReturnRefreshToken(request, int.Parse(userId));
			if (authorizationResponse.Result)
			{
				return Ok(authorizationResponse);
			}
			else
			{
				return BadRequest(authorizationResponse);
			}
		}
	}
}
