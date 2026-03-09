using Microsoft.AspNetCore.Mvc;
using TalentGrid.Application.Abstraction;
using TalentGrid.Application.Feature.Mentor.Queries.GetMentorAdvice;

namespace TalentGrid.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MentorController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public MentorController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet("advice")]
        public async Task<IActionResult> GetMentorAdvice([FromQuery] GetMentorAdviceQuery query)
        {
            var advice = await _queryDispatcher.Dispatch<GetMentorAdviceQuery, string>(query);
            if (string.IsNullOrEmpty(advice))
                return NotFound("No advice found for the given criteria.");
            return Ok(advice);
        }
    }
}
