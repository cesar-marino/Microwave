using Microwave.Presentation.Client.Models;

namespace Microwave.Presentation.Client.Microwave
{
    public interface IMicrowaveService
    {
        Task<List<ProgramModel>> GetListPrograms(CancellationToken cancellationToken = default);

        //Task<ProgramModel> CreateProgramAsync(CreateProgramRequest request);
        //Task<List<ProgramModel>> GetListPrograms();
        //Task<ProgramModel> RemoveProgramAsync(Guid programId);
        //Task<ProgramModel> UpdateProgramAsync(CreateProgramRequest request);

        //Task<ServiceModel> StartServiceAsync(StartServiceRequest request);
        //Task<ServiceModel> StopServiceAsync(Guid serviceId);
        //Task<ServiceModel> ResumeServiceAsync(Guid serviceId);

        //Task<UserModel> AuthenticationAsync(UserRequest request);
        //Task<UserModel> CreateUserAsync(UserRequest request);
    }
}
