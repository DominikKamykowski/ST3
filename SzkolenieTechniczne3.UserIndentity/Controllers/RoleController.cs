using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SzkolenieTechniczne3.UserIdentity.CrossCutting.dtos;
using SzkolenieTechniczne3.UserIdentity.CrossCutting.Services.Interfaces;

namespace SzkolenieTechniczne3.UserIdentity.Controllers
{
    [Route("/identity")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        //// Gets list of the roles
        //// </summary>
        /// <returns></returns>
        [HttpGet("roles")]
        public async Task<IEnumerable<RoleDto>> Read()
        {
            var dto = await _roleService.Read();
            return dto;
        }

        /// <summary>
        /// Gets role information by identifier
        /// </summary>
        /// <param name="id">Identifier of the role</param>
        /// <returns></returns>
        [HttpGet("roles/{id}")]
        public async Task<RoleDto> ReadById(Guid id)
        {
            var dto = await _roleService.ReadById(id);
            return dto;
        }

        /// <summary>
        /// Creates a new role entry. The identifier of the record will be automatically generated.
        /// </summary>
        /// <param name="dto">Data transfer object describing role</param>
        /// <returns></returns>
        [HttpPost("role")]
        public async Task<IActionResult> Create([FromBody] RoleDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dto = await _roleService.Create(dto);
            return Ok(dto);
        }

        /// <summary>
        /// Updates role information
        /// </summary>
        /// <param name="dto">Data transfer object describing role</param>
        /// <returns></returns>
        [HttpPut("role")]
        public async Task<IActionResult> Update([FromBody] RoleDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            dto = await _roleService.Update(dto);
            return Ok(dto);
        }

        /// <summary>
        /// Deletes existing role referenced by its identifier
        /// </summary>
        /// <param name="id">Identifier of the role</param>
        /// <returns></returns>
        [HttpDelete("role")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _roleService.Delete(id);
            return NoContent();
        }

        /// <summary>
        /// Assigns role to the user
        /// </summary>
        /// <param name="userId">Identifier of the user</param>
        /// <param name="roleIds">Identifiers of the roles</param>
        /// <returns></returns>
        [HttpPost("roles/assign-to-user")]
        public async Task<IActionResult> AssignRolesToUser(Guid userId, [FromBody] Guid[] roleIds)
        {
            await _roleService.AssignRolesToUser(userId, roleIds);
            return Ok();
        }
    }
}
