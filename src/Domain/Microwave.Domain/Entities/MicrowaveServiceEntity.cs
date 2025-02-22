using Microwave.Domain.Enums;
using Microwave.Domain.SeedWork;

namespace Microwave.Domain.Entities
{
    public class MicrowaveServiceEntity : EntityBase
    {
        public MicrowaveServiceStatus Status { get; }
        public HeatingProgramEntity HeatingProgram { get; }

        public MicrowaveServiceEntity(HeatingProgramEntity heatingProgram)
        {
            Status = MicrowaveServiceStatus.InProgress;
            HeatingProgram = heatingProgram;
        }

        public string Process()
        {
            var processResult = string.Empty;

            if (HeatingProgram.Seconds <= 0)
                return "Aquecimento concluído";

            for (int i = 0; i < HeatingProgram.Power; i++)
                processResult += HeatingProgram.Character;

            HeatingProgram.DecreaseTime();
            return processResult;
        }
    }
}
