using BlazorConcept.Api.Data;
using BlazorConcept.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorConcept.Api.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly DataContext _dataContext;

        public TeamRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Team> AddTeamAsync(Team team)
        {
            _dataContext.Teams.Add(team);
            await _dataContext.SaveChangesAsync();
            return team;
        }

        public async Task DeleteTeamAsync(int teamId)
        {
            Team team = await GetTeamByIdAsync(teamId);
            if (team == null)
            {
                return;
            }

            _dataContext.Teams.Remove(team);
            await _dataContext.SaveChangesAsync();
        }

        public IEnumerable<Team> GetAllITeams()
        {
            return _dataContext.Teams;
        }

        public async Task<Team> GetTeamByIdAsync(int teamId)
        {
            return await _dataContext.Teams.FirstOrDefaultAsync(t => t.Id == teamId);
        }

        public async Task<Team> UpdateTeamAsync(Team team)
        {
            Team foudTeam = await GetTeamByIdAsync(team.Id);
            if (foudTeam == null)
            {
                return null;
            }

            foudTeam.Name = team.Name;
            foudTeam.LogoPath = team.LogoPath;
            await _dataContext.SaveChangesAsync();
            return foudTeam;
        }
    }
}