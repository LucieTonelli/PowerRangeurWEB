using Azure;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PowerRangeurAPI.API.DTOs.Tache;
using PowerRangeurAPI.API.DTOs.User;
using System.Net.Http.Json;

namespace PowerRangeurWEB.Dialogs
{
    public partial class AssignDialog
    {
        public List<UserGet> Users { get; set; } = [];

        [CascadingParameter] BlazoredModalInstance? BlazoredModal { get; set; } = default!;


        [Parameter]
        public TacheGet Tache { get; set; }

        [Inject]
        public HttpClient HttpClient { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Users = await this.HttpClient.GetFromJsonAsync<List<UserGet>>("/api/user/all");
            Tache = await this.HttpClient.GetFromJsonAsync<TacheGet>("/api/tache/byId/" + Tache.IdTache);

        }

        public void Add(UserGet user)
        {
            Tache.Users.Add(user);
        }

        public void Remove(UserGet user)
        {
            Tache.Users.RemoveAll(u => user.IdUser == u.IdUser);
        }

        public async void Sauver ()
        {
            await HttpClient.PatchAsJsonAsync("/api/tache/Assign/" + Tache.IdTache, Tache.Users.Select(user => user.IdUser));
            StateHasChanged();
            await BlazoredModal?.CloseAsync(ModalResult.Ok(Tache));
        }




    }
}


