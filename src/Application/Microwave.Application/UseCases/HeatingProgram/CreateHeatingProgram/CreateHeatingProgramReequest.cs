using MediatR;
using Microwave.Application.UseCases.HeatingProgram.Commons;

namespace Microwave.Application.UseCases.HeatingProgram.CreateHeatingProgram
{
    public class CreateHeatingProgramReequest(
        int seconds,
        int power,
        string name,
        string food,
        char character,
        string? instructions) : IRequest<HeatingProgramResponse>
    {
        public int Seconds { get; } = seconds;
        public int Power { get; } = power;
        public string Name { get; } = name;
        public string Food { get; } = food;
        public char Character { get; } = character;
        public string? Instructions { get; } = instructions;
    }
}
