using BlazorConcept.Shared.Entities;
using BlazorConcept.Web.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorConcept.Web.Pages
{
    public class TeamsBase : ComponentBase
    {
        [Inject]
        public ITeamsDataService TeamsDataService { get; set; }

        public IEnumerable<Team> Teams { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Teams = (await TeamsDataService.GetAllTeamsAsync()).ToList();
        }
    }
}
