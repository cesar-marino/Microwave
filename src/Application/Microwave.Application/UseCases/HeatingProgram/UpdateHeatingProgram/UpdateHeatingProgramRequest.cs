using MediatR;
using Microwave.Application.UseCases.HeatingProgram.Commons;

namespace Microwave.Application.UseCases.HeatingProgram.UpdateHeatingProgram
{
    public class UpdateHeatingProgramRequest(
        int seconds,
        int power,
        char character,
        string name,
        string food,
        string? instructions) : IRequest<HeatingProgramResponse>
    {
        public int Seconds { get; } = seconds;
        public int Power { get; } = power;
        public char Character { get; } = character;
        public string Name { get; } = name;
        public string Food { get; } = food;
        public string? Instructions { get; } = instructions;
    }
}
