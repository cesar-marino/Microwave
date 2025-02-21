using Microwave.Domain.Entities;

namespace Microwave.Application.UseCases.HeatingProgram.Commons
{
    public class HeatingProgramResponse(
        Guid heatingProgramId,
        bool predefined,
        int seconds,
        int power,
        char character,
        string name,
        string food,
        string? instructions)
    {
        public Guid HeatingProgramId { get; } = heatingProgramId;
        public bool Predefined { get; } = predefined;
        public int Seconds { get; } = seconds;
        public int Power { get; } = power;
        public char Character { get; } = character;
        public string Name { get; } = name;
        public string Food { get; } = food;
        public string? Instructions { get; } = instructions;

        public static HeatingProgramResponse FromEntity(HeatingProgramEntity heatingProgram) => new(
            heatingProgramId: heatingProgram.Id,
            predefined: heatingProgram.Predefined,
            seconds: heatingProgram.Seconds,
            power: heatingProgram.Power,
            character: heatingProgram.Character,
            name: heatingProgram.Name,
            food: heatingProgram.Food,
            instructions: heatingProgram.Instructions);
    }
}
