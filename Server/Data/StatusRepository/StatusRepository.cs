using Microsoft.EntityFrameworkCore;
using Tasky.Shared;

namespace Tasky.Server.Data.StatusRepository
{
    public class StatusRepository : IStatusRepository
    {
        private readonly AppDbContext _context;

        public StatusRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<StatusNew> AddStatus(StatusNew status)
        {

            var result = await _context.Statuses.AddAsync(status);
            await _context.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<StatusNew> DeleteStatus(int id)
        {
            string message = string.Empty;
            var result = await _context.Statuses.FirstOrDefaultAsync<StatusNew>(x => x.StatusId == id);
            if (result == null)
            {
                message = "No status to delete";
                throw new Exception("No status to delete");
            }
            _context.Statuses.Remove(result);
            await _context.SaveChangesAsync();
            message = $"Status of {result.StatusName} has been deleted";
            return result;
        }

        public async Task<List<StatusNew>> GetAllStatuses()
        {
            string message = string.Empty;
            try
            {
                var result = await _context.Statuses.ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                message = "No status is available to return";
                throw new Exception(ex.Message);
            }
        }

        public async Task<StatusNew> GetStatusById(int id)
        {
            string message = string.Empty;
            var result = await _context.Statuses.FirstOrDefaultAsync(x => x.StatusId == id);
            try
            {
                if (result == null)
                {
                    message = $"There is no status with the id of {id}";
                    throw new Exception("Status is null");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<StatusNew> UpdateStatus(StatusNew status)
        {
            string message = string.Empty;
            var result = _context.Statuses.FirstOrDefault(x => x.StatusId == status.StatusId);
            if (result == null)
            {
                message = "Could not update status";
                throw new Exception("Cannot update status as it has returned null.");
            }

            result.StatusName = status.StatusName;
            result.StatusDefinitionOfFinished = status.StatusDefinitionOfFinished;
            result.WorkInProgressLimit = status.WorkInProgressLimit;

            await _context.SaveChangesAsync();
            return result;
        }
    }
}
