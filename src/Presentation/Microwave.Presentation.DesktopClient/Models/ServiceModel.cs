namespace Microwave.Presentation.DesktopClient.Models
{
    public class ServiceModel(
        Guid serviceId,
        ProgramModel program,
        string status) : ModelBase(serviceId)
    {
        public ProgramModel Program { get; } = program;
        public string Status { get; } = status;
    }
}
