using Microwave.Domain.Exceptions;
using Microwave.Domain.SeedWork;

namespace Microwave.Domain.Entities
{
    public class HeatingProgramEntity : EntityBase
    {
        public bool Predefined { get; }
        public int Seconds { get; private set; }
        public int Power { get; private set; }
        public char Character { get; private set; }
        public string Name { get; private set; }
        public string Food { get; private set; }
        public string? Instructions { get; private set; }

        public HeatingProgramEntity(int seconds = 30, int power = 10)
        {
            if (seconds < 1 || seconds > 120)
                throw new EntityValidationException(message: "Tempo inválido");

            if (power < 1 || power > 10)
                throw new EntityValidationException(message: "Potência inválida");

            Seconds = seconds;
            Power = power;
            Character = '.';
            Name = "Default";
            Food = "Default";
            Predefined = false;
        }

        public HeatingProgramEntity(
            Guid heatingProgramId,
            bool predefined,
            int seconds,
            int power,
            char character,
            string name,
            string food,
            string? instructions) : base(heatingProgramId)
        {
            Predefined = predefined;
            Seconds = seconds;
            Power = power;
            Character = character;
            Name = name;
            Food = food;
            Instructions = instructions;
        }

        public void AddTime()
        {
            if (Predefined)
                throw new ActionNotPermittedException(message: "Não é permitido adicionar tempo à programas pré definidos");

            Seconds += 30;
        }

        public void Update(
            int seconds,
            int power,
            char character,
            string name,
            string food,
            string instructions)
        {
            if (Predefined)
                throw new ActionNotPermittedException(message: "Não é permitido alterar programas pré definidos");

            Seconds = seconds;
            Power = power;
            Character = character;
            Name = name;
            Food = food;
            Instructions = instructions;
        }
    }
}
