using Microsoft.AspNetCore.Mvc;
using TalentGrid.Application.Abstraction;
using TalentGrid.Application.Contracts.Dto;
using TalentGrid.Application.Feature.Skills.Command;
using TalentGrid.Application.Feature.Skills.Queries.GetSkillsByEmployee;

namespace TalentGrid.Api.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    public class TalentController : ControllerBase
    {
        private readonly IQueryDispatcher _dispatcher;
        private readonly ICommandDispatcher _commandDispatcher;
        public TalentController(IQueryDispatcher dispatcher, ICommandDispatcher commandDispatcher)
        {
            _dispatcher = dispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string skillName, [FromQuery] int minLevel = 1)
        {
            var query = new GetSkillsByEmployeeQuery { SkillName = skillName, MinLevel = minLevel };
            var result = await _dispatcher.Dispatch<GetSkillsByEmployeeQuery, List<SearchTalentDto>>(query);
            if (result == null || !result.Any())
                return NotFound("No talents found matching the criteria.");
            return Ok(result);
        }

        [HttpPost("add-skill")]
        public async Task<IActionResult> AddSkillToEmployee([FromBody] AddEmployeeSkillsCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok("Skill added successfully.");
        }
    }
}
