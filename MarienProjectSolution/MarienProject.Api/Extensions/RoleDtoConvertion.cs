using MarienProject.Api.Models;
using MarienProject.Models.Dtos;

namespace MarienProject.Api.Extensions
{
    public static class RoleDtoConvertion
    {
        public static IEnumerable<RoleDto> ConvertToDto(this IEnumerable<Role> roles)
        {
            return (from role in roles
                    select new RoleDto
                    {
                        Id = role.Id,
                        Name = role.Name,
                        Description = role.Description
                    }).ToList(); 
        }
        public static RoleDto ConvertToDtoAction(this Role roles)
        {
            return new RoleDto()
            {
                Id = roles.Id,
                Name =  roles.Name,
                Description = roles.Description
            };
        }
    }
}
