using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Text.Json;
using PowerRangeurAPI.Domain.Models;
using System.Net.Http.Json;
using PowerRangeurAPI.API.DTOs.Tache;
using PowerRangeurAPI.API.DTOs.User;
using System.Runtime.CompilerServices;

namespace PowerRangeurWEB.Pages
{
    public partial class AssignerRangeur
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int IdTache { get; set; }

        public IEnumerable<UserGet> Users { get; set; } = [];

        //protected override async Task OnInitializedAsync()
        //{
        //    List<UserGet> users = await HttpClient.GetFromJsonAsync<List<UserGet>>("/api/user/all");

        //}




        //private async Task AjouterRangeur (TacheGet tache)
        //{
        //    Tache nouvelletache = new Tache
        //    {
        //        NomTache = tache.NomTache,
        //        Statut = tache.Statut,
        //        PrioriteTaches = tache.PrioriteTaches,
        //        Recurrence = tache.Recurrence,
        //        Description = tache.Description,
        //        DateEcheance = tache.DateEcheance,
        //        Users = Users.ToList()

        //    };


        //}

    //private async Task AddRangeur(int idTache)
    //{
    //    var response = await HttpClient.PatchAsync(
    //        $"/api/Tache/Assign/{idTache}",
    //        new StringContent(
    //            JsonSerializer.Serialize(new { }),
    //            System.Text.Encoding.UTF8,
    //            "application/json"
    //        ));

    //    if (response.IsSuccessStatusCode)
    //    {
    //        // Handle success
    //        var tache = await response.Content.ReadFromJsonAsync<TacheGet>();
    //        // Do something with the tache object
    //    }
    //    else
    //    {
    //        // Handle error
    //    }
    //}
}
}

