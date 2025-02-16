using Microwave.Domain.Exceptions;
using Microwave.Domain.SeedWork;
using Microwave.Domain.Validations;

namespace Microwave.Domain.Entities
{
    public class HeatingProgramEntity : EntityBase
    {
        public bool Predefined { get; private set; }
        public int Seconds { get; private set; }
        public int Power { get; private set; }
        public string Name { get; private set; }
        public string Food { get; private set; }
        public char Character { get; private set; }
        public string? Instructions { get; private set; }

        public HeatingProgramEntity(
            int? seconds,
            int? power,
            string name = "Deafult",
            string food = "default",
            char character = '.',
            string? instructions = null)
        {
            Predefined = false;
            Seconds = seconds ?? 30;
            Power = power ?? 10;
            Name = name;
            Food = food;
            Character = character;
            Instructions = instructions;

            Validate();
        }

        public HeatingProgramEntity(
            Guid heatingProgramId,
            bool predefined,
            int seconds,
            int power,
            string name,
            string food,
            char character,
            string? instructions) : base(heatingProgramId)
        {
            Predefined = predefined;
            Seconds = seconds;
            Power = power;
            Name = name;
            Food = food;
            Character = character;
            Instructions = instructions;
        }

        public void Update(
            string name,
            string food,
            string? instructions,
            char character,
            int seconds,
            int power)
        {
            Seconds = seconds;
            Power = power;
            Name = name;
            Character = character;
            Food = food;
            Instructions = instructions;
        }


        public void AddSeconds(int seconds)
        {
            if (Predefined)
                throw new EntityValidationException(message: "Não é possível adicionar tempo à programas pré definidos");

            Seconds = seconds;
        }

        public void DecreaseTime() => Seconds--;

        private void Validate()
        {
            var validator = new HeatingProgramValidator();
            var results = validator.Validate(this);

            if (!results.IsValid)
            {
                var message = string.Empty;
                foreach (var error in results.Errors)
                    message += $" - {error.ErrorCode}: {error.ErrorMessage}";

                throw new EntityValidationException(message: message);
            }
        }
    }
}
