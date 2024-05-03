using Microsoft.AspNetCore.Components;
using PowerRangeurAPI.API.DTOs.Tache;
using PowerRangeurAPI.Domain.Models;
using System.Net.Http.Json;
using ZendeskApi_v2.Models.Articles;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;

namespace PowerRangeurWEB.Pages
{
    //public partial class CreationTache
    //{
    //    private async Task CreerTache(TacheFormCreate tache)
    //    {

    //        Tache nouvelletache = new Tache()
    //        {
    //            NomTache = tache.NomTache,
    //            Statut = tache.Statut,
    //            PrioriteTaches = tache.PrioriteTaches,
    //            Recurrence = tache.Recurrence,
    //            Description = tache.Description,
    //            DateEcheance = tache.DateEcheance,
    //            PointBonusMalus = tache.PointBonusMalus
    //        };
    //        using var response = await HttpClient.PostAsJsonAsync<Tache>("api/tache", nouvelletache);
    //        Article article = await response.Content.ReadFromJsonAsync<Article>();

    //        HttpResponseMessage response = await HttpClient.PostAsJsonAsync("/api/tache", tache);
    //        if (response.IsSuccessStatusCode)
    //        {
    //            await OnInitializedAsync();
    //        }
    //        else
    //        {
    //            await OnInitializedAsync();
    //        }
    //    }
    //}

    public partial class CreationTache
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        public TacheFormCreate Tache { get; set; } = new TacheFormCreate();
        private async Task CreerTache()
        {


            //Tache nouvelletache = new Tache()
            //{
            //    NomTache = tache.NomTache,
            //    Statut = tache.Statut,
            //    PrioriteTaches = tache.PrioriteTaches,
            //    Recurrence = tache.Recurrence,
            //    Description = tache.Description,
            //    DateEcheance = tache.DateEcheance,
            //    PointBonusMalus = tache.PointBonusMalus
            //};

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
