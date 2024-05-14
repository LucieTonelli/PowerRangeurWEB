using Microsoft.AspNetCore.Components;
using PowerRangeurAPI.API.DTOs.Tache;
using PowerRangeurAPI.Domain.Models;
using System.Net.Http.Json;
using ZendeskApi_v2.Models.Articles;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;

namespace PowerRangeurWEB.Pages
{
    public partial class CreationTache
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        [SupplyParameterFromForm]

        public TacheFormCreate Tache { get; set; } = new TacheFormCreate();
        private async Task CreerTache()
        {
            HttpResponseMessage response = await HttpClient.PostAsJsonAsync("/api/tache", Tache);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("ok");
            }
            else
            {
                Console.WriteLine("Notok");
            }
        }
    }
}
