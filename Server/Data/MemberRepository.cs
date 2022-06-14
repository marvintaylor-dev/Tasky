using Microsoft.EntityFrameworkCore;
using Tasky.Shared;

namespace Tasky.Server.Data
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext _context;

        public MemberRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Member>> GetMembers()
        {
            return await _context.Members.ToListAsync();
        }
    }
}
