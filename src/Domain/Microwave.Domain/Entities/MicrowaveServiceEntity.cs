using Microwave.Domain.Enums;
using Microwave.Domain.SeedWork;

namespace Microwave.Domain.Entities
{
    public class MicrowaveServiceEntity(HeatingProgramEntity heatingProgram) : EntityBase
    {
        public HeatingProgramEntity HeatingProgram = heatingProgram;
        public MicrowaveServiceStatus Status { get; private set; } = MicrowaveServiceStatus.InProgress;

        public string Heat()
        {
            var processedResult = string.Empty;

            if (HeatingProgram.Seconds > 0 && Status == MicrowaveServiceStatus.InProgress)
            {
                for (int i = 0; i < HeatingProgram.Power; i++)
                    processedResult += HeatingProgram.Character;

                HeatingProgram.DecreaseTime();
            }
            else
            {
                Status = MicrowaveServiceStatus.Completed;
                processedResult += "Aquecimento concluído";
            }

            return processedResult;
        }

        public void Stop()
        {
            Status = Status != MicrowaveServiceStatus.Paused
                ? Status = MicrowaveServiceStatus.Paused
                : MicrowaveServiceStatus.Canceled;
        }

        public void AddSeconds(int seconds) => HeatingProgram.AddSeconds(seconds);

        public void Pause() => Status = MicrowaveServiceStatus.Paused;

        public void Cancel() => Status = MicrowaveServiceStatus.Canceled;
    }
}
