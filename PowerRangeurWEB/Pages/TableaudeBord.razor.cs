using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PowerRangeurAPI.API.DTOs.User;
using PowerRangeurWEB.Dialogs;
using System.Net.Http.Json;


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
        public UserReport? User { get; private set; }

        private List<UserReport> _userReports = new List<UserReport>();

        protected override async Task OnInitializedAsync()
        {

            _userReports = new List<UserReport>
            {
                new UserReport { IdUser = 1, PseudoUser = "User1", Score = 100 },
                new UserReport { IdUser = 2, PseudoUser = "User2", Score = 200 },
                new UserReport { IdUser = 3, PseudoUser = "User3", Score = 300 }
            };
            //int userId = 1; // Remplacez par l'ID utilisateur renvoyer via authentification ou autre ?
            //HttpResponseMessage response = await HttpClient.GetAsync($"/api/User/ById/{userId}");
            //if (response.IsSuccessStatusCode)
            //{
            //    var data = await response.Content.ReadFromJsonAsync<UserReport>();
            //    if (data != null)
            //    {
            //        _userReports.Add(data);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Erreur lors de la récupération des données.");
            //}
        }

        private async Task RapportUser()
        {

            HttpResponseMessage response = await HttpClient.GetAsync($"/api/User/ById/{IdUser}");
            if (response.IsSuccessStatusCode)
            {
                User = await response.Content.ReadFromJsonAsync<UserReport>();
                Console.WriteLine("ok");
            }
            else
            {
                Console.WriteLine("Notok");
            }
        }





        public async void DetailUser(UserGet u)
        {
            ModalParameters parameters = new()
            {
                { "User", u }
            };

            var assignModal = await ModalService.Show<RapportDialog>("voir le rapport user", parameters).Result;
            await RapportUser();
            StateHasChanged();
        }

    }
}