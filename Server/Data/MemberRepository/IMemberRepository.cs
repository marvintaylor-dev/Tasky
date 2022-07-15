using Tasky.Shared;

namespace Tasky.Server.Data.MemberRepository
{
    public interface IMemberRepository
    {
        Task<ServiceResponse<List<Member>>> GetMembers();
    }
}
