using Tasky.Shared;

namespace Tasky.Client.Services
{
    public interface IMemberService
    {
        Task<List<Member>> GetMembers();
    }
}
