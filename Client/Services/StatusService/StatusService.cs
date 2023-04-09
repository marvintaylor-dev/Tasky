using System.Security.Cryptography.X509Certificates;
using Tasky.Shared;
using Tasky.Shared.DTOs;

namespace Tasky.Client.Services.StatusService
{
    public class StatusService : IStatusService
    {
        private readonly HttpClient _httpClient;

        public StatusService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<StatusDTO> AddStatus(StatusDTO status)
        {
            var result = await _httpClient.PostAsJsonAsync("api/status", status);
            var response = await result.Content.ReadFromJsonAsync<StatusDTO>();

            if (response == null)
            {
                throw new Exception("Could not add new status.");
            }

            return response;
        }

        public async Task<StatusDTO> DeleteStatus(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/status/{id}");
            var response = await result.Content.ReadFromJsonAsync<StatusDTO>();

            if (response == null)
            {
                throw new Exception("Could not delete status.");
            }
            return response;
        }

        public async Task<List<StatusDTO>> GetAllStatuses()
        {
            var result = await _httpClient.GetFromJsonAsync<List<StatusDTO>>("api/status");
            if(result == null)
            {
                throw new Exception("No Statuses found.");
            }
            return result;
        }

        public async Task<StatusDTO> GetStatusById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<StatusDTO>($"api/status/{id}");
            if(result == null)
            {
                throw new Exception($"No status by id of {id} were found.");
            }
            return result;
        }

        public async Task<StatusDTO> UpdateStatus(StatusDTO status)
        {
            //Get the id from the database so we can update the status and not get a header error.
            //var name = status.StatusName;
            //var fullStatus = await GetStatusByName(name);
            //status.StatusId = fullStatus.StatusId;

            var result = await _httpClient.PutAsJsonAsync($"api/status/{status.StatusId}", status);
            var response = await result.Content.ReadFromJsonAsync<StatusDTO>();
            
            return response;
        }

        public async Task<StatusDTO> GetStatusByName(string statusName)
        {
            var result = await _httpClient.GetFromJsonAsync<StatusDTO>($"api/status/name/{statusName}");
            if(result == null)
            {
                throw new Exception($"Could not update status of {statusName}");
            }
            return result;
        }

        public async Task<StatusDTO> GetLastStatus()
        {
            var statuses = await GetAllStatuses();
            var lastStatus = statuses.OrderByDescending(x => x.StatusOrder).First();
            return lastStatus;
        }

        public async Task<StatusDTO> GetFirstStatus()
        {
            var statuses = await GetAllStatuses();
            var firstStatus = statuses.OrderBy(x => x.StatusOrder).First();
            return firstStatus;
        }

        public async Task<StatusDTO> GetSecondStatus()
        {
            var statuses = await GetAllStatuses();
            var secondStatus = statuses.OrderBy(x => x.StatusOrder).ElementAt(1);
            return secondStatus;
        }
    }
}
