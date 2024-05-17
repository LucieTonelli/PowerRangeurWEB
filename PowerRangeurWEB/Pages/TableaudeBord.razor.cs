using Azure;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PowerRangeurAPI.API.DTOs.Tache;
using PowerRangeurAPI.API.DTOs.User;
using PowerRangeurAPI.Domain.Models;
using PowerRangeurWEB.Dialogs;
using System.Net.Http.Json;
using ZendeskApi_v2.Requests;


namespace PowerRangeurWEB.Pages
{
    public partial class TableaudeBord
    {
        [CascadingParameter]
        public IModalService ModalService { get; set; }

        [Inject]
        public HttpClient HttpClient { get; set; }

        [Parameter]
        public int IdUser { get; set; }

        private List<UserGet> _users = new List<UserGet>();

        protected override async Task OnInitializedAsync()
        {
            var users = await HttpClient.GetFromJsonAsync<List<UserGet>>("/api/user/all");
            if (users != null)
            {
                _users.AddRange(users);
            }
            else
            {
                Console.WriteLine("Erreur lors de la récupération des données.");
            }
        }

        private async Task RapportUser()
        {
            HttpResponseMessage response = await HttpClient.GetAsync($"/api/User/ById/{IdUser}");
            if (response.IsSuccessStatusCode)
            {
                UserReport userReport = await response.Content.ReadFromJsonAsync<UserReport>();
                Console.WriteLine("ok");
            }
            else
            {
                Console.WriteLine("Notok");
            }
        }

        public async Task DetailUser(int idUser)
        {
            ModalParameters parameters = new()
            {
        { "IdUser", idUser }
            };

            var assignModal = await ModalService.Show<RapportDialog>("Voir le rapport utilisateur", parameters).Result;
            StateHasChanged();
        }
    }
}