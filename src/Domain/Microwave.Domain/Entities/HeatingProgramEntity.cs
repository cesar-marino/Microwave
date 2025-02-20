using Microwave.Domain.Exceptions;
using Microwave.Domain.SeedWork;

namespace Microwave.Domain.Entities
{
    public class HeatingProgramEntity : EntityBase
    {
        public int Seconds { get; private set; }
        public int Power { get; private set; }
        public char Character { get; private set; }

        public HeatingProgramEntity(int seconds = 30, int power = 10)
        {
            if (seconds < 1 || seconds > 120)
                throw new EntityValidationException(message: "Tempo inválido");

            if (power < 1 || power > 10)
                throw new EntityValidationException(message: "Potência inválida");

            Seconds = seconds;
            Power = power;
            Character = '.';
        }

        public void AddTime() => Seconds += 30;

        public string Process()
        {
            var processResult = string.Empty;
            for (int i = 0; i < Power; i++)
                processResult += Character;

            return processResult;
        }
    }
}
