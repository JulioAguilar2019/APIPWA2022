using Apitest.Models;
using Apitest.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Apitest.Services;
using Apitest.dbContexts;
using System.Linq;

namespace Apitest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly UsersdbContext _context;
        public UserController(IUserService userService, UsersdbContext dbContext)
        {
            _userService = userService;
            _context = dbContext;
        }

        [HttpGet("Get")]       

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

        [HttpPost("Create")]
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

        [HttpPut("Edit")]

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

        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteUserAsync(int id)
        {
            try
            {
                await _userService.DestroyAsync(id);
                return Ok("Usuario eliminado correctamente");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }



    }
}
