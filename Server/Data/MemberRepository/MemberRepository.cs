using Microsoft.EntityFrameworkCore;
using Tasky.Shared;

namespace Tasky.Server.Data.MemberRepository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext _context;

        public MemberRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Member>>> GetMembers()
        {
            var response = new ServiceResponse<List<Member>>
            {
                Data = await _context.Members.ToListAsync()
            };
            return response;
        }
    }
}
