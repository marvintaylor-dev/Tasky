using Tasky.Shared;

namespace Tasky.Server.Data.MemberRepository
{
    public interface IMemberRepository
    {
        Task<ServiceResponse<List<Member>>> GetMembers();
        Task<ServiceResponse<Member>> GetMemberById(int id);
        Task<ServiceResponse<Member>> GetMemberByName(string name);
        Task<Member> AddMember(Member member);
        Task<Member> DeleteMemberById(int id);
        Task<Member> UpdateMember(Member member);
    }
}
