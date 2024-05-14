using Blazored.Modal.Services;
using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using PowerRangeurAPI.API.DTOs.Tache;
using PowerRangeurWEB.Dialogs;
using System.Net.Http.Json;

namespace PowerRangeurWEB.Pages
{
    public partial class DetailTache
    {

        [Inject]
        public HttpClient HttpClient { get; set; }

        [CascadingParameter]
        public IModalService ModalService { get; set; }

        [Parameter]
        public int IdTache { get; set; }

        public TacheGet Tache { get; set; } = new TacheGet();

        public TacheFormComplete TachetoComplete { get; set; } = new TacheFormComplete();

        protected override async Task OnParametersSetAsync()
        {
            if (IdTache != null)
            {
                Tache.IdTache = IdTache;
                await InfoTache();
            }
        }


        private async Task InfoTache()
        {

            HttpResponseMessage response = await HttpClient.GetAsync($"/api/Tache/ById/{IdTache}");
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

        protected override async Task OnInitializedAsync()
        {
            InfoTache();
            StateHasChanged();
        }



        public async void Assign(TacheGet t)
        {
            ModalParameters parameters = new()
            {
                { "Tache", t }
            };

            var assignModal = await ModalService.Show<AssignDialog>("Assigner des utilisateurs", parameters).Result; ;
            await InfoTache();
            StateHasChanged();
        }

        private bool isTaskCompleted;


        protected override void OnAfterRender(bool firstRender)
        {
            if (isTaskCompleted)
            {
                // Effectuez ici les actions à exécuter lorsque la tâche est terminée
                Console.WriteLine("La tâche est terminée !");
            }
        }
    }

}
