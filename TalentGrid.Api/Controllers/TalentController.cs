using Microsoft.AspNetCore.Mvc;
using TalentGrid.Application.Contracts.Dto;
using TalentGrid.Application.Contracts.UseCase;

namespace TalentGrid.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TalentController: ControllerBase
    {
        private readonly ISearchTalent _searchTalen;

        public TalentController(ISearchTalent searchTalent)
        {
            _searchTalen = searchTalent;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string skillName, [FromQuery] int minLevel= 1) 
        {
            var result = await _searchTalen.SearchTalents(skillName, minLevel);
            if (result == null || !result.Any())
                return NotFound("No talents found matching the criteria.");
            return Ok(result);
        }
    }
}
