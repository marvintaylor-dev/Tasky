using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using Tasky.Shared;

namespace Tasky.Server.Data.MemberRepository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public MemberRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Member> AddMember(Member member)
        {
            Member response;
            if (member.Name != null)
            {
                _context.Members.Add(member);
                _context.SaveChanges();
                response = member;
            }
            else
            {
                throw new Exception("Could not add new member.");
            }
            return response;
        }

        public async Task<Member> DeleteMemberById(int id)
        {
            var member = await _context.Members.FirstOrDefaultAsync(x => x.MemberId == id);
            if(member == null)
            {
                throw new Exception("No member found to delete");
            }
            var tasks = _context.Tasks.Where(x => x.Assignee == id);
            foreach( var task in tasks)
            {
                task.Assignee = 0;
            }
            

            _context.Remove(member);
            _context.SaveChanges();

            return member;
        }

        public async Task<ServiceResponse<Member>> GetMemberById(int id)
        {
            var data = await _context.Members.FirstOrDefaultAsync(x => x.MemberId == id);
            var response = new ServiceResponse<Member>();
            if (data == null)
            {
                response.Data = null;
            }
            else
            {
                response.Data = data;
            }
            return response;
        }

        public Task<ServiceResponse<Member>> GetMemberByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<Member>>> GetMembers()
        {
            var response = new ServiceResponse<List<Member>>
            {
                Data = await _context.Members.ToListAsync()
            };
            return response;
        }

        public async Task<Member> UpdateMember(Member member)
        {
            var memberInDB = await _context.Members.FirstOrDefaultAsync(x => x.MemberId == member.MemberId);
            if (memberInDB == null)
            {
                throw new Exception($"{member.Name} was not found and could not be updated.");
            }
           _mapper.Map(member, memberInDB);
           _context.SaveChanges();
            
           return member;
            
        }
    }
}
