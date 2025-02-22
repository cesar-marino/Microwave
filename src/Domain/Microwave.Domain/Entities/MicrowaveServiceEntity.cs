using Microwave.Domain.Enums;
using Microwave.Domain.Exceptions;
using Microwave.Domain.SeedWork;

namespace Microwave.Domain.Entities
{
    public class MicrowaveServiceEntity : EntityBase
    {
        public MicrowaveServiceStatus Status { get; private set; }
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

        public void Stop()
        {
            if (Status == MicrowaveServiceStatus.Canceled
                || Status == MicrowaveServiceStatus.Completed)
                throw new ActionNotPermittedException("O programa não esta em andamento");

            Status = Status != MicrowaveServiceStatus.Paused
                ? MicrowaveServiceStatus.Paused
                : MicrowaveServiceStatus.Canceled;
        }
    }
}
