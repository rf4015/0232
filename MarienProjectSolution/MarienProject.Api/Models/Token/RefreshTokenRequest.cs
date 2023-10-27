namespace MarienProject.Api.Models.Token
{
	public class RefreshTokenRequest
	{
        public string TokenExpired { get; set; }
        public string RefreshToken { get; set; }
    }
}
