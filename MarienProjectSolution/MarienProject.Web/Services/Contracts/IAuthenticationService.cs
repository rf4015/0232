using System.Threading.Tasks;

namespace MarienProject.Web.Services.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> Login(string username, string password);
        Task<bool> RefreshToken();
        Task<string> GetUserRole();
        public string GetAccessToken();
        public string GetRefreshToken();
        Task AddAuthorizationHeader(HttpClient httpClient);
    }
}
