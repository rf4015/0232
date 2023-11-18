using Bogus;
using MarienProject.Api.Extensions;
using MarienProject.Api.Extentions;
using MarienProject.Api.Models;
using MarienProject.Api.Repositories;
using MarienProject.Api.Repositories.Contracts;
using MarienProject.Models.Dtos;
using MarienProject.Models.Dtos.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarienProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        private readonly ILogger<RoleController> _logger;

        public RoleController(IRoleRepository roleRepository, ILogger<RoleController> logger)
        {
            _roleRepository = roleRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetAllRoles()
        {
            var roles = await _roleRepository.GetAllRoles();

            if (roles == null)
            {
                return NotFound();
            }
            else
            {
                var rolesDto = roles.ConvertToDto();
                return Ok(rolesDto);
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateRole([FromBody] RoleActionsDto roleDto)
        {
            try
            {
                var role = roleDto.ConvertToAddRole();
                var createStaus = await _roleRepository.CreateRole(role);

                if (createStaus == false)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(createStaus);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating an role");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<RoleDto>> GetRoleById(int id)
        {
            try
            {
                var roles = await _roleRepository.GetRoleById(id);
                if (roles == null) 
                {
                    return NotFound(id);
                }
                else
                {
                    var roleDto = roles.ConvertToDtoAction();
                    return Ok(roleDto);
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "An error occurred while retrieving role data");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteRole(int id)
        {
            try
            {
                var deleteStatus = await _roleRepository.DeleteRole(id);
                if (deleteStatus == false)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(deleteStatus);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting an role");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<bool>> UpdateRole( int id, RoleActionsDto roleDto)
        {
            try
            {
                var role = roleDto.ConvertToAddRole();
                var updateStatus = await _roleRepository.UpdateRole(id, role);
                if (updateStatus == false)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(updateStatus);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating an role");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
