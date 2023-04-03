using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using System.Reflection.Metadata;
using Tasky.Shared;
using Tasky.Shared.DTOs;

namespace Tasky.Server.Data.StatusRepository
{
    public class StatusRepository : IStatusRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public StatusRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StatusDTO> AddStatus(StatusDTO status)
        {
            try
            {
                //Convert Dto to model
                var parameterToModel = _mapper.Map<Status>(status);
                await _context.Statuses.AddAsync(parameterToModel);
                await _context.SaveChangesAsync();
                var result = _mapper.Map<StatusDTO>(parameterToModel);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<StatusDTO> DeleteStatus(int id)
        {
            
            var matchingStatus = await _context.Statuses.FirstOrDefaultAsync(x => x.StatusId == id);
            if (matchingStatus == null)
            {
                throw new Exception("No status to delete");
            }
            _context.Statuses.Remove(matchingStatus);
            await _context.SaveChangesAsync();

            var deletedDTO = _mapper.Map<StatusDTO>(matchingStatus);

            return deletedDTO;
        }

        public async Task<List<StatusDTO>> GetAllStatuses()
        {
            try
            {
                var result = await _context.Statuses.OrderBy(x => x.StatusOrder).ToListAsync();
                var statusResponse = new List<StatusDTO>();
                result.ForEach(result => statusResponse.Add(new StatusDTO
                {
                    StatusId = result.StatusId,
                    WorkInProgressLimit = result.WorkInProgressLimit,
                    StatusDefinitionOfFinished = result.StatusDefinitionOfFinished,
                    StatusOrder = result.StatusOrder,   
                    StatusName = result.StatusName,
                })); 
                return statusResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<StatusDTO> GetStatusById(int id)
        {
            string message = string.Empty;
            var matchingStatus = await _context.Statuses.FirstOrDefaultAsync(x => x.StatusId == id);
            try
            {
                if (matchingStatus == null)
                {
                    throw new Exception("Status is null");
                }
                var result = _mapper.Map<StatusDTO>(matchingStatus);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<StatusDTO> GetStatusIdByName(string name)
        {
            var reducedName = name.ToLower().Trim().Replace(" ", "");
            var result = await _context.Statuses
                .FirstOrDefaultAsync(x => x.StatusName.ToLower().Trim().Replace(" ", "") == reducedName);
            if (result == null)
            {
                throw new Exception($"{name} is not found.");
            }

            var status = _mapper.Map<StatusDTO>(result);
                     
            return status;
        }

        public async Task<StatusDTO> UpdateStatus(StatusDTO status)
        {
            var foundStatusInDb = _context.Statuses.FirstOrDefault(x => x.StatusId == status.StatusId);
            if (foundStatusInDb == null)
            {
                throw new Exception("Cannot update status as it has returned null.");
            }
            foundStatusInDb.StatusOrder = status.StatusOrder;
            foundStatusInDb.StatusName = status.StatusName;
            foundStatusInDb.StatusDefinitionOfFinished = status.StatusDefinitionOfFinished;
            foundStatusInDb.WorkInProgressLimit = status.WorkInProgressLimit;
            
            await _context.SaveChangesAsync();

            var result = _mapper.Map<StatusDTO>(foundStatusInDb);

            return result;
        }
    }
}

