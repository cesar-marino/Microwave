using MediatR;
using Microwave.Application.UseCases.HeatingProgram.Commons;
using System.ComponentModel.DataAnnotations;

namespace Microwave.Application.UseCases.HeatingProgram.UpdateHeatingProgram
{
    public class UpdateHeatingProgramRequest(
        Guid heatingProgramId,
        int seconds,
        int power,
        char character,
        string name,
        string food,
        string? instructions) : IRequest<HeatingProgramResponse>
    {
        [Required]
        public Guid HeatingProgramId { get; } = heatingProgramId;

        [Required]
        [MinLength(1)]
        [MaxLength(120)]
        public int Seconds { get; } = seconds;

        [Required]
        [MinLength(1)]
        [MaxLength(10)]
        public int Power { get; } = power;

        [Required]
        public char Character { get; } = character;

        [Required]
        public string Name { get; } = name;

        [Required]
        public string Food { get; } = food;

        public string? Instructions { get; } = instructions;
    }
}
