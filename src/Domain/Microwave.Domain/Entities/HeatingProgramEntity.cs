using Microwave.Domain.Exceptions;
using Microwave.Domain.SeedWork;

namespace Microwave.Domain.Entities
{
    public class HeatingProgramEntity(
        int seconds = 30,
        int power = 10,
        string name = "Default",
        string food = "Default",
        char character = '.',
        string? instructions = null,
        bool predefined = false,
        Guid? heatingProgramId = null) : EntityBase(heatingProgramId)
    {
        public bool Predefined { get; } = predefined;
        public int Seconds { get; private set; } = seconds;
        public int Power { get; private set; } = power;
        public string Name { get; private set; } = name;
        public string Food { get; private set; } = food;
        public char Character { get; private set; } = character;
        public string? Instructions { get; private set; } = instructions;

        public void IncreaseTime(int seconds)
        {
            if (Predefined)
                throw new EntityValidationException(message: "Cannot add time to a preset program");

            Seconds += seconds;
        }

        public void DecreaseTime() => Seconds--;

        public void Update(
            int seconds,
            int power,
            string name,
            string food,
            char character,
            string? instructions)
        {
            if (Predefined)
                throw new EntityValidationException(message: "Cannot change a preset program");

            Seconds = seconds;
            Power = power;
            Name = name;
            Food = food;
            Character = character;
            Instructions = instructions;
        }
    }
}
