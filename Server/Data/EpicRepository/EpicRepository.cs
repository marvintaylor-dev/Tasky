using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tasky.Client.Services.TaskService;
using Tasky.Shared;

namespace Tasky.Server.Data.EpicRepository
{
    public class EpicRepository : IEpicRepository
    {

        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        public EpicRepository(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<Epic> CreateEpic(Epic Epic)
        {
            var newEpic = await _db.Epics.AddAsync(Epic);
            await _db.SaveChangesAsync();
            return newEpic.Entity;

        }

        public async Task<Epic> DeleteEpic(int Id)
        {
            Epic result = await _db.Epics.FirstOrDefaultAsync(s => s.EpicId == Id) ?? throw new Exception("Could not find Epic id");

            if (result != null)
            {

                _db.Epics.Remove(result);
                await _db.SaveChangesAsync();
                return result;
            }
            else
            {
                throw new Exception($"Epic with Id = {Id} not found");
            }

        }

        public async Task<Epic> GetEpicById(int Id)
        {
            Epic singleEpic = await _db.Epics.FirstOrDefaultAsync(s => s.EpicId.Equals(Id)) ?? throw new Exception("Could not find Epic id");

            if (singleEpic != null)
            {
                return singleEpic;
            }
            else
            {
                throw new Exception($"Epic with an Id of {Id} was not found");
            }
        }

        public async Task<List<Epic>> GetAllEpics()
        {
            var result = await _db.Epics.ToListAsync();
            if (result == null)
            {
                throw new Exception("No Epics were found");
            }
            else
            {
                return result;
            }
        }

        public async Task<Epic> UpdateEpic(Epic Epic)
        {
            Epic result = _db.Epics.Include(x => x.UserStoriesInEpic).FirstOrDefault(s => s.EpicId == Epic.EpicId) ?? throw new Exception($"Could not find id");
            // _mapper.Map(Epic, result);

            //result.EpicId = Epic.EpicId;
            if (Epic != null)
            {
                result.EpicName = Epic.EpicName;
                result.EpicBudget = Epic.EpicBudget;
                result.EpicCategory = Epic.EpicCategory;
                result.EpicColor = Epic.EpicColor;
                result.UserStoriesInEpic = Epic.UserStoriesInEpic;
            }





            await _db.SaveChangesAsync();
            return result;
        }
    }
}
