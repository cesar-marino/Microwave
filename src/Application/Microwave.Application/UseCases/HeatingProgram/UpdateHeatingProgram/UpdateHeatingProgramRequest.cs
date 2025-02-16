using MediatR;
using Microwave.Application.UseCases.HeatingProgram.Commons;

namespace Microwave.Application.UseCases.HeatingProgram.UpdateHeatingProgram
{
    public class UpdateHeatingProgramRequest(
        Guid heatingProgramId,
        int seconds,
        int power,
        string name,
        string food,
        string? instructions,
        char character) : IRequest<HeatingProgramResponse>
    {
        public Guid HeatingProgramId { get; } = heatingProgramId;
        public int Seconds { get; } = seconds;
        public int Power { get; } = power;
        public string Name { get; } = name;
        public string Food { get; } = food;
        public string? Instructions { get; } = instructions;
        public char Character { get; } = character;
    }
}
