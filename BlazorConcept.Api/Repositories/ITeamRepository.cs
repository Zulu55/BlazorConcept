using BlazorConcept.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorConcept.Api.Repositories
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetAllITeams();

        Task<Team> GetTeamByIdAsync(int teamId);

        Task<Team> AddTeamAsync(Team team);

        Task<Team> UpdateTeamAsync(Team team);

        Task DeleteTeamAsync(int teamId);
    }
}
