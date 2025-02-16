using Microwave.Domain.Entities;

namespace Microwave.Application.UseCases.HeatingProgram.Commons
{
    public class HeatingProgramResponse(
        Guid heatingProgramId,
        bool predefined,
        int seconds,
        int power,
        string name,
        string food,
        string? instructions,
        char character)
    {
        public Guid HeatingProgramId { get; } = heatingProgramId;
        public bool Predefined { get; } = predefined;
        public int Seconds { get; } = seconds;
        public int Power { get; } = power;
        public string Name { get; } = name;
        public string Food { get; } = food;
        public string? Instructions { get; } = instructions;
        public char Character { get; } = character;

        public static HeatingProgramResponse FromEntity(HeatingProgramEntity heatingProgram) => new(
            heatingProgramId: heatingProgram.Id,
            predefined: heatingProgram.Predefined,
            seconds: heatingProgram.Seconds,
            power: heatingProgram.Power,
            name: heatingProgram.Name,
            food: heatingProgram.Food,
            instructions: heatingProgram.Instructions,
            character: heatingProgram.Character);
    }
}
