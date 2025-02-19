using Microwave.Domain.Entities;
using Microwave.Domain.Enums;
using Microwave.Domain.SeedWork;

namespace Microwave.Domain.Exceptions
{
    public class MicrowaveProgramEntity(HeatingProgramEntity heatingProgram) : EntityBase
    {
        public HeatingProgramEntity HeatingProgram { get; } = heatingProgram;
        public MicrowaveServiceStatus ServiceStatus { get; private set; } = MicrowaveServiceStatus.InProgress;
    }
}
