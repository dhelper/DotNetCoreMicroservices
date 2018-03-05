using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using LunchService.Controllers;
using Newtonsoft.Json;

namespace LunchService.Accessors
{
    public interface IUserAccessor
    {
        Task<IEnumerable<Friend>> GetFriendsByLocationAsync(string location);
    }

    public class UserAccessor : IUserAccessor
    {
        private readonly HttpClient client;
        public UserAccessor()
        {
            client = new HttpClient {BaseAddress = new Uri("http://userservice:80")};
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<IEnumerable<Friend>> GetFriendsByLocationAsync(string location)
        {
            var response = await client.GetAsync($"api/Users/{location}");
            if (response.IsSuccessStatusCode)
            {
                var stringResult = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<Friend>>(stringResult);
            }

            return Enumerable.Empty<Friend>();
        }
    }
}
