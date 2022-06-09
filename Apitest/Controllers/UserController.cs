using Apitest.Models;
using Apitest.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Apitest.Services;

namespace Apitest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUser")]
       

        public async Task<ActionResult<List<users>>> GetUsersAsync()
        {
            try
            {
                var users = await _userService.GetUsersAsync();
                return Ok(users);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id:int}", Name = "GetUserById")]
        public async Task<ActionResult<users>> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);

                if (user != null) return Ok(user);

                return NotFound();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<users>> CreateUserAsync(users user)
        {
            try
            {
                var savedUser = await _userService.CreateUserAsync(user);
                if (savedUser != null) return CreatedAtRoute("GetUserById", new { id = savedUser.user_id }, savedUser);
                return NotFound();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]

        public async Task<ActionResult<users>> UpdateUserAsync(users user)
        {
            try
            {
                var updateUser = await _userService.UpdateAsync(user);
                return Ok(updateUser);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUserAsync(int id)
        {
            try
            {
                await _userService.DestroyAsync(id);
                return Ok("Producto eliminado correctamente");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}
