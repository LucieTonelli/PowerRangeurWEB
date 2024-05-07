using DocuSign.eSign.Model;
using Microsoft.AspNetCore.Components;
using PowerRangeurAPI.API.DTOs.Tache;
using System.Net.Http;
using System.Net.Http.Json;

namespace PowerRangeurWEB.Pages
{
    public partial class DetailTache
    {

        [Inject]
        public HttpClient HttpClient { get; set; }

        [Parameter]
        public string IdTache { get; set; }

        private int idTache;
        public TacheGet Tache { get; set; } = new TacheGet();

        protected override async Task OnParametersSetAsync()
        {
            if (int.TryParse(IdTache, out int result))
            {
                idTache = result;
                Tache.IdTache = idTache;
                await InfoTache();
            }
        }



        private async Task InfoTache()
        {
           
            HttpResponseMessage response = await HttpClient.PostAsJsonAsync("/api/Tache/ById/", Tache);
            if (response.IsSuccessStatusCode)
            {
                Tache = await response.Content.ReadFromJsonAsync<TacheGet>();
                Console.WriteLine("ok");
            }
            else
            {
                Console.WriteLine("Notok");
            }
        }

        protected override void OnParametersSet()
        {
            if (int.TryParse(IdTache, out int result))
            {
                idTache = result;
                InfoTache();
            }

        }

    }
}
