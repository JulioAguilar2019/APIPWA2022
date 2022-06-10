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
    public class BriefCaseController : ControllerBase
    {
        private readonly IBriefCaseService _briefCaseService;

        public BriefCaseController(IBriefCaseService briefCaseService)
        {
            _briefCaseService = briefCaseService;
        }

        [HttpGet("Get")]

        public async Task<ActionResult<List<briefcase>>> GetBriefcaseAsync()
        {
            try
            {
                var briefcases = await _briefCaseService.GetBriefcaseAsync();
                return Ok(briefcases);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id:int}", Name = "GetBriefById")]
        public async Task<ActionResult<briefcase>> GetBriefcaseById(int id)
        {
            try
            {
                var briefcase = await _briefCaseService.GetbriefcaseByIdAsync(id);

                if (briefcase != null) return Ok(briefcase);

                return NotFound();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult<briefcase>> CreateBriefAsync(briefcase briefcases)
        {
            try
            {
                var savedBrief = await _briefCaseService.CreatebriefcaseAsync(briefcases);
                if (savedBrief != null) return CreatedAtRoute("GetBriefById", new { id = savedBrief.bc_id }, savedBrief);
                return NotFound();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("Edit")]

        public async Task<ActionResult<briefcase>> UpdateBriefAsync(briefcase Brief)
        {
            try
            {
                var updateBrief = await _briefCaseService.UpdateAsync(Brief);
                return Ok(updateBrief);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteBriefAsync(int id)
        {
            try
            {
                await _briefCaseService.DestroyAsync(id);
                return Ok("Portafolio eliminado correctamente");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }

}
