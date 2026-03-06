using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TalentGrid.Application;
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
        private readonly IQueryHandler<GetSkillsByEmployeeQuery, List<SearchTalentDto>> _handler;

        public TalentController(IQueryHandler<GetSkillsByEmployeeQuery, List<SearchTalentDto>> handler)
        {
            _handler = handler;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string skillName, [FromQuery] int minLevel= 1) 
        {
            var query = new GetSkillsByEmployeeQuery { SkillName = skillName, MinLevel = minLevel };
            var result = await _handler.Handle(query);
            if (result == null || !result.Any())
                return NotFound("No talents found matching the criteria.");
            return Ok(result);
        }

        // Implement endpoint for create new skill for username
    }
}
