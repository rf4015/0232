using MarienProject.Models.Dtos;

namespace MarienProject.Api.Repositories.Contracts;

public interface IUserRepository
{
    Task<bool> RegisterUser(UserRegisterRequestDto request);
}
