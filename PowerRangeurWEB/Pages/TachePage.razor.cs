using Microsoft.AspNetCore.Components;
using PowerRangeurAPI.API.DTOs.Tache;
using PowerRangeurAPI.Domain.Models;
using System.Net.Http.Json;

namespace PowerRangeurWEB.Pages
{
    public partial class TachePage
    {

        public IEnumerable<TacheGet> TachesLibres { get; set; } = [];
        public IEnumerable<TacheGet> TachesEnCours { get; set; } = [];
        public IEnumerable<TacheGet> TachesTerminees { get; set; } = [];

        //[Parameter]
        //public string IdTache { get; set; }


        [Inject]
        public HttpClient HttpClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            List<TacheGet> taches = await HttpClient.GetFromJsonAsync<List<TacheGet>>("/api/tache/all");
            TachesLibres = taches.Where(t => t.Statut == Tache.Status.Libre);
            TachesEnCours = taches.Where(t => t.Statut == Tache.Status.Encours);
            TachesTerminees = taches.Where(t => t.Statut == Tache.Status.Terminee);
        }




        private async Task CreerTache(TacheFormCreate tache)
        {
            Tache nouvelletache = new Tache
            {
                NomTache = tache.NomTache,
                Statut = tache.Statut,
                PrioriteTaches = tache.PrioriteTaches,
                Recurrence = tache.Recurrence,
                Description = tache.Description,
                DateEcheance = tache.DateEcheance,
                //PointBonusMalus = tache.PointBonusMalus
            };

            HttpResponseMessage response = await HttpClient.PostAsJsonAsync("/api/tache", tache);
            if (response.IsSuccessStatusCode)
            {
                await OnInitializedAsync();
            }
            else
            {
                await OnInitializedAsync();
            }
        }


        //méthode pour naviguer vers la page de détails de la tâche (avec injection de NavigationManager)
        private void GetById (int idTache)
        {
            NavigationManager.NavigateTo($"/DetailTache/{idTache}");
        }


    }
}
