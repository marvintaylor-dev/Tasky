using System.Runtime.InteropServices;
using Tasky.Shared.DTOs;

namespace Tasky.Client.Services.MemberService
{
    public class MemberService : IMemberService
    {
        public List<MemberDTO> Members { get; set; } = new();
        public MemberDTO SingleMember { get; set; } = new();

        private readonly HttpClient _httpClient;

        public MemberService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task GetMembers()
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<MemberDTO>>>("api/members");
            if (result != null && result.Data != null)
                Members = result.Data;
        }

        public async Task GetMemberById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<MemberDTO>>($"api/members/{id}");
            if (result != null && result.Data != null)
                SingleMember = result.Data;
        }

        public Task<MemberDTO> GetMemberByName(string Name)
        {
            throw new NotImplementedException();
        }

        public async Task<MemberDTO> AddMember(MemberDTO newMember)
        {
            var result = await _httpClient.PostAsJsonAsync("api/members", newMember);
            var response = result.Content.ReadFromJsonAsync<ServiceResponse<MemberDTO>>();
            if (response.Result.Data == null)
            {
                throw new Exception("Error from client side.");
            }
            return response.Result.Data;
        }

        public async Task<MemberDTO> UpdateMember(MemberDTO updateMember)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/members/{updateMember.MemberId}", updateMember);
            var response = result.Content.ReadFromJsonAsync<ServiceResponse<MemberDTO>>();
            if(response.Result.Data == null)
            {
                throw new Exception("Error from client side.");
            }
            return response.Result.Data;
        }

        public async Task<MemberDTO> DeleteMember(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/members/{id}");
            var response = result.Content.ReadFromJsonAsync<ServiceResponse<MemberDTO>>();
            if (response.Result.Data == null)
            {
                throw new Exception("Error from client side.");
            }
            return response.Result.Data;
        }
    }
}
