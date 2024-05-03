using DocuSign.eSign.Model;
using Microsoft.AspNetCore.Components;
using PowerRangeurAPI.API.DTOs.Tache;
using System.Net.Http;
using System.Net.Http.Json;

namespace PowerRangeurWEB.Pages
{
    public partial class DetailTache
    {
        private string? errorMessage;

        [Inject]
        public HttpClient HttpClient { get; set; }

        public TacheGet Tache { get; set; } = new TacheGet();

        private async Task InfoTache()
        {

            HttpResponseMessage response = await HttpClient.PostAsJsonAsync("/api/Tache/ById", Tache);
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
