using Tasky.Shared;
using System.Net.Http.Json;

namespace Tasky.Client.Services
{
    public class MemberService : IMemberService
    {
       private readonly HttpClient _httpClient;

        public MemberService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Member>> GetMembers()
        {
            
            var members = await _httpClient.GetFromJsonAsync<List<Member>>("api/members");

            if(members == null)
            {
                return null;
            }

            return members;
        }
    }
}
