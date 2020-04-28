using BlazorConcept.Shared.Entities;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorConcept.Web.Services
{
    public class TeamsDataService : ITeamsDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _api;

        public TeamsDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _api = "api/teams";
        }

        public async Task<Team> AddTeamAsync(Team team)
        {
            StringContent teamJson = new StringContent(JsonSerializer.Serialize(team), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(_api, teamJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Team>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task DeleteTeamAsync(int teamId)
        {
            await _httpClient.DeleteAsync($"{_api}/{teamId}");
        }

        public async Task<IEnumerable<Team>> GetAllTeamsAsync()
        {
            Stream response = await _httpClient.GetStreamAsync(_api);
            return await JsonSerializer.DeserializeAsync<IEnumerable<Team>>(response, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<Team> GetTeamDetailsAsync(int teamId)
        {
            Stream response = await _httpClient.GetStreamAsync($"{_api}/{teamId}");
            return await JsonSerializer.DeserializeAsync<Team>(response, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task UpdateTeamAsync(Team team)
        {
            StringContent teamJson = new StringContent(JsonSerializer.Serialize(team), Encoding.UTF8, "application/json");
            await _httpClient.PutAsync(_api, teamJson);
        }
    }
}
