using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PowerRangeurAPI.API.DTOs.Tache;
using PowerRangeurAPI.API.DTOs.User;
using PowerRangeurAPI.Domain.Models;
using System.Net.Http.Json;


namespace PowerRangeurWEB.Dialogs
{
    public partial class RapportDialog
    { 

    [CascadingParameter] 
    BlazoredModalInstance? BlazoredModalUser { get; set; } = default!;


    [Parameter]
    public int IdUser { get; set; }

    public UserReport User {  get; set; }


    [Inject]
    public HttpClient HttpClient { get; set; }


    protected override async Task OnInitializedAsync()
    {
            HttpResponseMessage response = await HttpClient.GetAsync($"/api/User/ById/{User.IdUser}");
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
}
}
