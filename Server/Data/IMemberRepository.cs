using Tasky.Shared;

namespace Tasky.Server.Data
{
    public interface IMemberRepository
    {
       Task<List<Member>> GetMembers();
    }
}
