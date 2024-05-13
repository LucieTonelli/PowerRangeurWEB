﻿using Blazored.Modal.Services;
using Blazored.Modal;
using DocuSign.eSign.Model;
using Microsoft.AspNetCore.Components;
using PowerRangeurAPI.API.DTOs.Tache;
using PowerRangeurAPI.API.DTOs.User;
using PowerRangeurAPI.Domain.Models;
using PowerRangeurWEB.Dialogs;
using System.Net.Http;
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

        protected override async Task OnParametersSetAsync()
        {
            if (IdTache != null)
            {
                Tache.IdTache = IdTache;
                await InfoTache();
            }
        }

        //protected override void OnParametersSet()
        //{ 
        
        //}


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
            await ModalService.Show<AssignDialog>("Assigner des utilisateurs", parameters).Result;
            await OnInitializedAsync();

        }




    }
}
