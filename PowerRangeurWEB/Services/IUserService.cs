using Microsoft.AspNetCore.Components;
using PowerRangeurAPI.API.DTOs.User;

namespace PowerRangeurWEB.Services
{
    public interface IUserService
    {

        [Inject]
        public HttpClient UserHttpClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        Task<IEnumerable<UserGet>> GetAllUsers();



    }
}
