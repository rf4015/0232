using MarienProject.Api.Models;
using MarienProject.Api.Repositories.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace MarienProject.Api.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly MarienPharmacyContext _dbFarmaciaContext;
        private readonly ILogger<RoleRepository> _logger;

        public RoleRepository(MarienPharmacyContext dbFarmaciaContext, ILogger<RoleRepository> logger)
        {
            _dbFarmaciaContext = dbFarmaciaContext;
            _logger = logger;
        }
        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            try
            {
                var roles = await _dbFarmaciaContext.Roles
                            .ToArrayAsync();
                return roles;
            }
            catch (Exception ex )
            {

                _logger.LogError(ex, "An error occurred while getting all Roles");
                return null;
            }
        }
        public async Task<Role> GetRoleById(int id)
        {
            try
            {
                var roles = await _dbFarmaciaContext.Roles
                    .FirstOrDefaultAsync(r => r.Id == id); 

                if(roles == null)
                {
                    throw new Exception("Role not found");
                }
                return roles;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "An error occurred while getting the role");
                return null;
            }
        }

        public async Task<bool> CreateRole(Role role)
        {
            try
            {
                _dbFarmaciaContext.Roles.Add(role);
                await _dbFarmaciaContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while creating the role: ", ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateRole(int id, Role updateRole)
        {
            Role role = await _dbFarmaciaContext.Roles
                .FirstOrDefaultAsync(r => r.Id == id );

            if (role != null)
            {
                try
                {
                    //role.Id = updateRole.Id;
                    role.Name = updateRole.Name;
                    role.Description = updateRole.Description;

                    //_dbFarmaciaContext.Roles.Update(role);
                    _dbFarmaciaContext.Entry(role).State = EntityState.Modified;

                    await _dbFarmaciaContext.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while updating the role");
                    return false;
                }
            }
            return false;
        }
        public async Task<bool> DeleteRole(int id)
        {
            var role = await _dbFarmaciaContext.Roles.FirstOrDefaultAsync(r => r.Id == id);

            if (role != null) 
            {
                try
                {
                    _dbFarmaciaContext.Roles.Remove(role);
                    await _dbFarmaciaContext.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while deleting the employee by Id");
                    return false; ;
                }
            }
            return false;
        }
    }
}
