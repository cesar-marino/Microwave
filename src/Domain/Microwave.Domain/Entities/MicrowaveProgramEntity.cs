using Microwave.Domain.Enums;
using Microwave.Domain.SeedWork;

namespace Microwave.Domain.Entities
{
    public class MicrowaveProgramEntity : EntityBase
    {
        public MicrowaveServiceStatus Status { get; }
        public HeatingProgramEntity HeatingProgram { get; }

        public MicrowaveProgramEntity(HeatingProgramEntity heatingProgram)
        {
            Status = MicrowaveServiceStatus.InProgress;
            HeatingProgram = heatingProgram;
        }
    }
}
