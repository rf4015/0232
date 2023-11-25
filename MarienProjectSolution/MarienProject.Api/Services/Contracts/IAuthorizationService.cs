using MarienProject.Models.Dtos;
using MarienProject.Models.Dtos.JWT;

namespace MarienProject.Api.Services.Contracts
{
	public interface IAuthorizationService
	{
		Task<AuthorizationResponseDto> ReturnToken(UserLoginRequestDto request);
		Task<AuthorizationResponseDto> ReturnRefreshToken(RefreshTokenRequestDto request, int UserId);

    }
}
