using Microsoft.AspNetCore.Components;
using PowerRangeurAPI.API.DTOs.Tache;
using PowerRangeurAPI.Domain.Models;
using System.Net.Http.Json;
using ZendeskApi_v2.Models.Articles;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using Microsoft.AspNetCore.Components.Forms;
using Org.BouncyCastle.Crypto.IO;
using System.IO;

namespace PowerRangeurWEB.Pages
{
    public partial class CreationTache
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        public TacheFormCreate Tache { get; set; } = new TacheFormCreate();
        private async Task CreerTache()
        {
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

        //test enregistrement de fichier
        //private string? _imageBase64;
        //private async Task OnFileChosen(InputFileChangeEventArgs args)
        //{
        //    using (var stream = args.File.OpenReadStream())
        //    {
        //        using (var memStream = new MemoryStream())
        //        {
        //            await stream.CopyToAsync(memStream);
        //            memStream.Position = 0;
        //            _imageBase64 = Convert.ToBase64String(memStream.ToArray());
        //        }
        //    }
        //}




    }
}
