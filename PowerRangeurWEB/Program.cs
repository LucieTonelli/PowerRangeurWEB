using Blazored.Modal;
using FluentValidation;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PowerRangeurAPI.API.DTOs.Tache;
using PowerRangeurWEB;
using PowerRangeurWEB.Validation;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7112/")
    });

builder.Services.AddBlazoredModal();
builder.Services.AddScoped<IValidator<TacheFormCreate>, TacheValidator>();

await builder.Build().RunAsync();
