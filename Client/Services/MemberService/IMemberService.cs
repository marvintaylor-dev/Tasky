using Tasky.Shared;
using Tasky.Shared.DTOs;

namespace Tasky.Client.Services.MemberService
{
    public interface IMemberService
    {
        List<MemberDTO> Members { get; set; }
        MemberDTO SingleMember { get; set; }
        Task GetMembers();
        Task GetMemberById(int id);
        Task<MemberDTO> GetMemberByName(string Name);
        Task<MemberDTO> AddMember(MemberDTO newMember);
        Task<MemberDTO> UpdateMember(MemberDTO updateMember);

        Task<MemberDTO> DeleteMember(int id);
    }
}
