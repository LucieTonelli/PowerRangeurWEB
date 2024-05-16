using Microsoft.AspNetCore.Components;
using PowerRangeurAPI.API.DTOs.User;
using System.Net.Http.Json;

namespace PowerRangeurWEB.Pages
{
    public partial class TableaudeBord
    {
        [Inject]
        public HttpClient HttpClient { get; set; }


        private List<UserReport> _userReports = new List<UserReport>();

        protected override async Task OnInitialized()
        {
            // Remplacez 'idHistory' par l'identifiant approprié ou obtenez-le dynamiquement
            var idHistory = 1;
            HttpResponseMessage response = await HttpClient.GetAsync($"/api/History/All");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<List<UserReport>>();
                if (data != null)
                {
                    _userReports = data;
                }
            }
            else
            {
                await Console.Out.WriteLineAsync("NotOK");
            }
        }

    }
}