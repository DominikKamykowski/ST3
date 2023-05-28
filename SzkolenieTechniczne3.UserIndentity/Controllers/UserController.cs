using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SzkolenieTechniczne3.UserIdentity.CrossCutting.dtos;
using SzkolenieTechniczne3.UserIdentity.CrossCutting.Services.Interfaces;
using SzkolenieTechniczne3.UserIndentity.Helpers;

namespace SzkolenieTechniczne3.UserIdentity.Controllers
{
    [Route("/identity")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create/user")]
        public async Task<IActionResult> CreateUser([FromBody] CreateNewUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dto.PhoneNumber = PhoneNumberHelper.SanitizePhoneNumber(dto.PhoneNumber);
            await _userService.Create(dto);
            return Ok();
        }

        [HttpGet("users/{id}")]
        public async Task<UserDto> ReadById(Guid id)
        {
            var dto = await _userService.ReadById(id);
            return dto;
        }

        /// <summary>
        /// Gets list of the users
        /// </summary>
        /// <returns></returns>
        [HttpGet("users")]
        public async Task<IEnumerable<UserDto>> Read()
        {
            var dto = await _userService.Read();
            return dto;
        }

        /// <summary>
        /// Updates user entity in database and Azure Active Directory
        /// </summary>
        /// <param name="dto">Data transfer object describing user</param>
        /// <returns></returns>
        [HttpPut("user")]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dto.PhoneNumber = PhoneNumberHelper.SanitizePhoneNumber(dto.PhoneNumber);

            dto = await _userService.Update(dto);


            return Ok(dto);
        }

        [HttpDelete("delete-user")]
        public async Task<IActionResult> DeleteByPhoneOrEmail([FromQuery][EmailAddress] string? email, [FromQuery] string? phoneNumber)
        {
            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(phoneNumber))
            {
                return BadRequest();
            }

            var phone = PhoneNumberHelper.SanitizePhoneNumber(phoneNumber);
            await _userService.DeleteByPhoneOrEmail(email, phoneNumber);            
            return Ok();
        }
    }
}

