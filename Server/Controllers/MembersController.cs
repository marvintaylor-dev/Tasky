using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Microsoft.AspNetCore.Mvc;
using Tasky.Server.Data.MemberRepository;
using Tasky.Shared;
using Tasky.Shared.DTOs;

namespace Tasky.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberRepository _repository;
        private readonly IMapper _mapper;

        public MembersController(IMemberRepository repo, IMapper mapper)
        {
            _repository = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<MemberDTO>>>> GetMembers()
        {
            var result = await _repository.GetMembers();
            List<MemberDTO> convertedMemberToDTO = _mapper.Map<List<MemberDTO>>(result.Data);
            var response = new ServiceResponse<List<MemberDTO>>
            {
                Data = convertedMemberToDTO
            };
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<MemberDTO>>> GetMemberById(int id)
        {
            var data = await _repository.GetMemberById(id);
            var response = new ServiceResponse<MemberDTO>();
            if (data.Data == null)
            {
                response.Data = null;
                response.Message = $"Could not find member of id: {id}";
                response.Success = false;
            }
            else
            {
                response.Data = _mapper.Map<MemberDTO>(data.Data);
                response.Message = "Success, found Member!";
                response.Success = true;
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<MemberDTO>>> AddMember(MemberDTO memberDTO)
        {
            var info = _mapper.Map<Member>(memberDTO);
            var data = await _repository.AddMember(info);
            var response = new ServiceResponse<MemberDTO>();
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                response.Data = _mapper.Map<MemberDTO>(data);
                response.Message = "Successfully added new member";
                response.Success = true;
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<MemberDTO>>> DeleteMember(int id)
        {
            var data = await _repository.DeleteMemberById(id);
            var info = _mapper.Map<MemberDTO>(data);
            
            var response = new ServiceResponse<MemberDTO>
            {
                Data = info,
                Message = $"Successfully Deleted {info.Name}",
                Success = true
            };
            return Ok(response);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<MemberDTO>>> UpdateMember(MemberDTO member)
        {
            var data = _mapper.Map<Member>(member);
            var dbResponse = await _repository.UpdateMember(data);
            var clientResponse = _mapper.Map<MemberDTO>(dbResponse);
            var serviceResponse = new ServiceResponse<MemberDTO>
            {
                Data = clientResponse,
                Message = $"Successfully updated {clientResponse.Name}'s information.",
                Success = true
            };
            return Ok(serviceResponse);
        }
    }

}
