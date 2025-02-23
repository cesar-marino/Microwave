using Microwave.Presentation.DesktopClient.Microwave.Dtos;
using Microwave.Presentation.DesktopClient.Models;

namespace Microwave.Presentation.DesktopClient.Microwave
{
    public interface IMicrowaveService
    {
        Task<ProgramModel> CreateProgramAsync(CreateProgramRequest request);
        Task<List<ProgramModel>> GetListPrograms();
        Task<ProgramModel> RemoveProgramAsync(Guid programId);
        Task<ProgramModel> UpdateProgramAsync(CreateProgramRequest request);

        Task<ServiceModel> StartServiceAsync(StartServiceRequest request);
        Task<ServiceModel> StopServiceAsync(Guid serviceId);
        Task<ServiceModel> ResumeServiceAsync(Guid serviceId);

        Task<UserModel> AuthenticationAsync(UserRequest request);
        Task<UserModel> CreateUserAsync(UserRequest request);
    }
}
