using BlazorConcept.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorConcept.Web.Services
{
    public interface ITeamsDataService
    {
        Task<IEnumerable<Team>> GetAllTeamsAsync();

        Task<Team> GetTeamDetailsAsync(int teamId);

        Task<Team> AddTeamAsync(Team team);

        Task UpdateTeamAsync(Team team);

        Task DeleteTeamAsync(int teamId);
    }
}
