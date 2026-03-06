using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TalentGrid.Application.Abstraction;
using TalentGrid.Application.Contracts.Dto;
using TalentGrid.Application.Contracts.UseCase;
using TalentGrid.Application.Feature.Skills.Queries.GetSkillsByEmployee;

namespace TalentGrid.Api.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    public class TalentController: ControllerBase
    {
        private readonly IQueryDispatcher _dispatcher;

        public TalentController(IQueryDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string skillName, [FromQuery] int minLevel= 1) 
        {
            var query = new GetSkillsByEmployeeQuery { SkillName = skillName, MinLevel = minLevel };
            var result = await _dispatcher.Dispatch<GetSkillsByEmployeeQuery, List<SearchTalentDto>>(query);
            if (result == null || !result.Any())
                return NotFound("No talents found matching the criteria.");
            return Ok(result);
        }

        // Implement endpoint for create new skill for username
    }
}
