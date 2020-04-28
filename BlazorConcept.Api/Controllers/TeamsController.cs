using BlazorConcept.Api.Repositories;
using BlazorConcept.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorConcept.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamRepository _teamRepository;

        public TeamsController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [HttpGet]
        public IActionResult GetTeams()
        {
            return Ok(_teamRepository.GetAllITeams().OrderBy(t => t.Name));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Team team = await _teamRepository.GetTeamByIdAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam([FromBody] Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Team newTeam = await _teamRepository.AddTeamAsync(team);
            return Created("team", newTeam);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Team teamToUpdate = await _teamRepository.GetTeamByIdAsync(team.Id);
            if (teamToUpdate == null)
            {
                return NotFound();
            }

            Team updatedTeam = await _teamRepository.UpdateTeamAsync(team);
            return Ok(updatedTeam);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Team teamToDelete = await _teamRepository.GetTeamByIdAsync(id);
            if (teamToDelete == null)
            {
                return NotFound();
            }

            await _teamRepository.DeleteTeamAsync(id);
            return Ok(teamToDelete);
        }
    }
}
