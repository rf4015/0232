using MarienProject.Api.Models;
using MarienProject.Api.Services.Contracts;
using MarienProject.Models.Dtos;
using MarienProject.Models.Dtos.JWT;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
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
		private string GenerateToken(int idUser)
		{
            var userProfile = _dbFarmaciaContext.UserProfiles.FirstOrDefault(r => r.Id == idUser);

            var employee = _dbFarmaciaContext.Employees.FirstOrDefault(e => e.UserId == userProfile.Id);
            var customer = _dbFarmaciaContext.Customers.FirstOrDefault(c => c.UserId == userProfile.Id);

            var privatekey = _configuration.GetValue<string>("JwtSetting:PrivateKey");
			var keyBytes = Encoding.ASCII.GetBytes(privatekey);

			//Creating users'data for JWT
			int? role = 0;

			if (employee != null) role = employee.RoleId;
			else role = customer.RoleId;

            var claims = new ClaimsIdentity();
			claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, idUser.ToString()));
			claims.AddClaim(new Claim(ClaimTypes.Role, role.ToString()));

            //Creating credentilas for JWT
            var credentialToken = new SigningCredentials(
				new SymmetricSecurityKey(keyBytes),
				SecurityAlgorithms.HmacSha256Signature
				);
			//Creating token' details
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = claims,//user's id
				Expires = DateTime.UtcNow.AddMinutes(60),
				SigningCredentials = credentialToken
			};

			//JWT's controller.
			var tokenHandle = new JwtSecurityTokenHandler();
			//Creating token with all details.
			var tokenConfig = tokenHandle.CreateToken(tokenDescriptor);
			//Getting token
			var tokenCreated = tokenHandle.WriteToken(tokenConfig);

			return tokenCreated;
		}
		private string GenerateRefreshToken()
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

		private async Task<AuthorizationResponseDto> SaveRefreshtokenHistory(
			int UserId,
			string token,
			string refreshToken)
		{
			var refreshtokenHistory = new RefreshTokenHistory
			{
				UserId = UserId,
				Token = token,
				RefreshToken = refreshToken,
				CreationDate = DateTime.UtcNow,
				ExpirationDate = DateTime.UtcNow.AddDays(3)
			};

			await _dbFarmaciaContext.RefreshTokenHistories.AddAsync(refreshtokenHistory);
			await _dbFarmaciaContext.SaveChangesAsync();

			return new AuthorizationResponseDto { Token = token, RefreshToken = refreshToken, Result = true, Msg = "OK" };
		}
		public async Task<AuthorizationResponseDto> ReturnToken(UserLoginRequestDto request)
		{
			var userFound = _dbFarmaciaContext.UserProfiles.FirstOrDefault(e =>
				e.UserName == request.UserName &&
				e.UserPassaword ==  request.Key
			);

			if(userFound == null )
			{
				return await Task.FromResult<AuthorizationResponseDto>(null);
			}

			//If there's an user with correct credential
			string tokenCreated = GenerateToken(userFound.Id);
			string TefreshTokenCreated = GenerateRefreshToken();

			// new AuthorizationResponse() { Token = tokenCreated, Result=true, Msg="Ok"};
			return await SaveRefreshtokenHistory(userFound.Id, tokenCreated, TefreshTokenCreated);
		}

		public async Task<AuthorizationResponseDto> ReturnRefreshToken(RefreshTokenRequestDto request, int userId)
		{
				//Finding refresh token
				var refreshTokenFound = _dbFarmaciaContext.RefreshTokenHistories.FirstOrDefault(h =>
					h.Token == request.TokenExpired &&
					h.RefreshToken == request.RefreshToken &&
					h.UserId == userId
				);

				if (refreshTokenFound == null)
				{
					return new AuthorizationResponseDto { Result = false, Msg = "Nonexistent Refresh token" };
				}

				var refreshTokenCreated = GenerateRefreshToken();
				var tokencreated = GenerateToken(userId);

                return await SaveRefreshtokenHistory(userId, tokencreated, refreshTokenCreated);
		}
    }
}
