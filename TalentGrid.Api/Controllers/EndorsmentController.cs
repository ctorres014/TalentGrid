using Microsoft.AspNetCore.Mvc;
using TalentGrid.Application.Abstraction;
using TalentGrid.Application.Feature.Endorsment.Command.AddEndorsmentSkills;

namespace TalentGrid.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EndorsmentController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public EndorsmentController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost("validate-skill")]
        public async Task<IActionResult> GiveEndorsment([FromBody] AddEndorsmentSkillsCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok("Validation successfully submitted. Thank you for fostering internal talent!");
        }
    }
}
