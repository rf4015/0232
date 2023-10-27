using MarienProject.Api.Models;
using MarienProject.Api.Models.Token;
using MarienProject.Api.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MarienProject.Api.Services
{
	public class AuthorizationService: IAuthorizationService
	{
		private readonly MarienPharmacyContext _dbFarmaciaContext;
		private readonly IConfiguration _configuration;

		public AuthorizationService(MarienPharmacyContext dbFarmaciaContext, IConfiguration configuration)
        {
			_dbFarmaciaContext = dbFarmaciaContext;
			_configuration = configuration;
		}
		private string GetToken(string idUser)
		{
			var privatekey = _configuration.GetValue<string>("JwtSetting:PrivateKey");
			var keyBytes = Encoding.ASCII.GetBytes(privatekey);

			var claims = new ClaimsIdentity();
			claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, idUser));

			var credentialToken = new SigningCredentials(
				new SymmetricSecurityKey(keyBytes),
				SecurityAlgorithms.HmacSha256Signature
				);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = claims,
				Expires = DateTime.UtcNow.AddMinutes(1),
				SigningCredentials = credentialToken
			};

			var tokenHandle = new JwtSecurityTokenHandler();
			var tokenConfig = tokenHandle.CreateToken(tokenDescriptor);

			var tokenCreated = tokenHandle.WriteToken(tokenConfig);

			return tokenCreated;
		}
		private string GetRefreshToken()
		{
			var byteArray = new byte[64];
			var refreshToken = "";

			using (var mg = RandomNumberGenerator.Create())
			{
				mg.GetBytes(byteArray);
				refreshToken = Convert.ToBase64String(byteArray);
			}
			return refreshToken;
		}

		private async Task<AuthorizationResponse> SaveRefreshtokenHistory(
			int UserId,
			string token,
			string refreshToken)
		{
			var refreshtokenHistory = new RefreshTokenHistory
			{
				UserId = UserId,
				Token = token,
				RefreshToken = refreshToken,
				ExpirationDate = DateTime.UtcNow,
				CreationDate = DateTime.UtcNow.AddDays(5)
			};

			await _dbFarmaciaContext.RefreshTokenHistories.AddAsync(refreshtokenHistory);
			await _dbFarmaciaContext.SaveChangesAsync();

			return new AuthorizationResponse { Token = token, RefreshToken = refreshToken, Result = true, Msg = "OK" };
		}
		public async Task<AuthorizationResponse> ReturnToken(AuthorizationRequest request)
		{
			var userFinded = _dbFarmaciaContext.UserProfiles.FirstOrDefault(e =>
				e.UserName == request.UserName &&
				e.UserPassaword ==  request.Key
			);

			if(userFinded == null )
			{
				return await Task.FromResult<AuthorizationResponse>(null);
			}
			string createdtoken = GetToken(userFinded.Id.ToString());
			return new AuthorizationResponse() { Token = createdtoken, Result = true, Msg = "OK" };
			string createdTefreshToken = GetRefreshToken();

			//return await SaveRefreshtokenHistory(userFinded.EmpleadoId, createdtoken, createdTefreshToken);
		}

		public async Task<AuthorizationResponse> ReturnRefreshToken(RefreshTokenRequest request, int userId)
		{
			var refreshTokenFound = _dbFarmaciaContext.RefreshTokenHistories.FirstOrDefaultAsync(h =>
				h.Token == request.TokenExpired &&
				h.RefreshToken == request.RefreshToken &&
				h.UserId == userId
			);

			if (refreshTokenFound == null)
			{
				return new AuthorizationResponse { Result = false, Msg = "Nonexistent Refresh token" };
			}

			var refreshTokenCreated = GetRefreshToken();
			var tokencreated = GetToken(userId.ToString());

			return await SaveRefreshtokenHistory(userId, tokencreated, refreshTokenCreated);
		}
	}
}
