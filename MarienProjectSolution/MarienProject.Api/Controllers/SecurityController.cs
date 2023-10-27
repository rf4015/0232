using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MarienProject.Api.Models.Token;
using MarienProject.Api.Services.Contracts;
using System.IdentityModel.Tokens.Jwt;

namespace MarienProject.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SecurityController : ControllerBase
	{
		private readonly IAuthorizationService _athorizationServive;

		public SecurityController(IAuthorizationService athorizationServive)
		{
			_athorizationServive = athorizationServive;
		}
		//Get token and refresh token throught the credential
		[HttpPost]
		[Route("Authenticate")]
		public async Task<IActionResult> Authenticate([FromBody] AuthorizationRequest request)
		{
			var result = await _athorizationServive.ReturnToken(request);

			if (result == null)
			{
				return Unauthorized();
			}

			return Ok(result);
		}

		//Get onother refresh token, throught another refresh token
		[HttpPost]
		[Route("GetRefreshToken")]
		public async Task<IActionResult> GetRefreshToken([FromBody] RefreshTokenRequest request)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenExpired = tokenHandler.ReadJwtToken(request.TokenExpired);

			if (tokenExpired.ValidTo > DateTime.UtcNow) return BadRequest(new AuthorizationResponse { Result = false, Msg = "Token hasn't expired yet" });

			string userId = tokenExpired.Claims.First(i =>
					i.Type == JwtRegisteredClaimNames.NameId).Value.ToString();

			var authorizationResponse = await _athorizationServive.ReturnRefreshToken(request, int.Parse(userId));
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
