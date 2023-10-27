using MarienProject.Api.Models.Token;

namespace MarienProject.Api.Services.Contracts
{
	public interface IAuthorizationService
	{
		Task<AuthorizationResponse> ReturnToken(AuthorizationRequest request);
		Task<AuthorizationResponse> ReturnRefreshToken(RefreshTokenRequest request, int UserId);
	}
}
