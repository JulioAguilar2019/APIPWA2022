using Apitest.Models;
using Apitest.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apitest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillsService _skillsService;

        public SkillsController(ISkillsService skillsService)
        {
            _skillsService = skillsService;
        }

        [HttpGet("Get")]

        public async Task<ActionResult<List<skills>>> GetSkillscaseAsync()
        {
            try
            {
                var skills = await _skillsService.GetSkillsAsync();
                return Ok(skills);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id:int}", Name = "GetSkillsfById")]
        public async Task<ActionResult<skills>> GetBriefcaseById(int id)
        {
            try
            {
                var skills = await _skillsService.GetSkillsByIdAsync(id);

                if (skills != null) return Ok(skills);

                return NotFound();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult<skills>> CreateSkillsAsync(skills Skills)
        {
            try
            {
                var savedSkills = await _skillsService.CreateSkillsAsync(Skills);
                if (savedSkills != null) return CreatedAtRoute("GetSkillsfById", new { id = savedSkills.skill_id }, savedSkills);
                return NotFound();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpPut("Edit")]

        public async Task<ActionResult<skills>> UpdateSkillsAsync(skills Skills)
        {
            try
            {
                var updateSkills = await _skillsService.UpdateAsync(Skills);
                return Ok(updateSkills);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteSkillsAsync(int id)
        {
            try
            {
                await _skillsService.DestroyAsync(id);
                return Ok("Habilidades eliminadas correctamente");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
