using Microwave.Domain.Exceptions;
using Microwave.Domain.SeedWork;

namespace Microwave.Domain.Entities
{
    public class HeatingProgramEntity : EntityBase
    {
        public int Seconds { get; private set; }
        public int Power { get; private set; }

        public HeatingProgramEntity(int seconds, int power = 10)
        {
            if (seconds < 1 || seconds > 120)
                throw new EntityValidationException(message: "Tempo inválido");

            Seconds = seconds;
            Power = power;
        }
    }
}
