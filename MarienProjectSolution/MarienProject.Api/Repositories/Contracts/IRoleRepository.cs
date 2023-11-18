using MarienProject.Api.Models;

namespace MarienProject.Api.Repositories.Contracts
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllRoles();
        Task<bool> CreateRole(Role role);
        Task<Role> GetRoleById(int id);
        Task<bool> UpdateRole(int id, Role updateRole);
        Task<bool> DeleteRole(int id);
    }
}
