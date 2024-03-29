using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MF.Application.Models.User;
using MF.Application.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace MF.Web.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRequestModel request)
        {
            await _userService.Create(request);
            if (_userService.IsValid())
            {
                return NoContent();    
            }
            return BadRequest(_userService.GetNotfications());

        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UserRequestModel request)
        {
            await _userService.Update(id, request);
            if(_userService.IsValid())
                return NoContent();
            return BadRequest(_userService.GetNotfications());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _userService.Delete(id);
            if(_userService.IsValid())
                return NoContent();
            return BadRequest(_userService.GetNotfications());
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<UserResponseModel> GetById([FromRoute] Guid id)
        {
            return await _userService.GetById(id);
        }

        [HttpGet]
        public async Task<IList<UserResponseModel>> GetAll()
        {
            return await _userService.GetAll();
        }
    }
}