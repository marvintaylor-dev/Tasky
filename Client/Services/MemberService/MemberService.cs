namespace Tasky.Client.Services.MemberService
{
    public class MemberService : IMemberService
    {
        public List<Member> Members { get; set; } = new List<Member>();

        private readonly HttpClient _httpClient;

        public MemberService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task GetMembers()
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Member>>>("api/members");
            if (result != null && result.Data != null)
                Members = result.Data;
        }
    }
}
