using Tasky.Shared;

namespace Tasky.Client.Services.MemberService
{
    public interface IMemberService
    {
        List<Member> Members { get; set; }
        Task GetMembers();
    }
}
