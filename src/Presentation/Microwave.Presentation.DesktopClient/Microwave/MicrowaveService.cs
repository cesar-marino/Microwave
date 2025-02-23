using Microwave.Presentation.DesktopClient.Microwave.Dtos;
using Microwave.Presentation.DesktopClient.Models;
using Newtonsoft.Json;

namespace Microwave.Presentation.DesktopClient.Microwave
{
    public class MicrowaveService : IMicrowaveService
    {
        public Task<UserModel> AuthenticationAsync(UserRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ProgramModel> CreateProgramAsync(CreateProgramRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> CreateUserAsync(UserRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProgramModel>> GetListPrograms()
        {
            try
            {
                using var client = new HttpClient();
                using var response = await client.GetAsync("");
                var programsJsonString = await response.Content.ReadAsStringAsync();
                var programs = JsonConvert.DeserializeObject<List<ProgramModel>>(programsJsonString);

                return programs ?? [];
            }
            catch
            {
                throw;
            }
        }

        public Task<ProgramModel> RemoveProgramAsync(Guid programId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceModel> ResumeServiceAsync(Guid serviceId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceModel> StartServiceAsync(StartServiceRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceModel> StopServiceAsync(Guid serviceId)
        {
            throw new NotImplementedException();
        }

        public Task<ProgramModel> UpdateProgramAsync(CreateProgramRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
