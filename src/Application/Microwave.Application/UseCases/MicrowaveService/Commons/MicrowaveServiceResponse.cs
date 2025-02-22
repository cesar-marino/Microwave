using Microwave.Domain.Entities;
using Microwave.Domain.Enums;

namespace Microwave.Application.UseCases.MicrowaveService.Commons
{
    public class MicrowaveServiceResponse(
        Guid microwaveServiceId,
        MicrowaveServiceStatus status,
        ServiceHeatingProgramResponse heatingProgram)
    {
        public Guid MicrowaveServiceId { get; } = microwaveServiceId;
        public MicrowaveServiceStatus Status { get; } = status;
        public ServiceHeatingProgramResponse HeatingProgram { get; } = heatingProgram;

        public static MicrowaveServiceResponse FromEntity(MicrowaveServiceEntity microwaveService) => new(
            microwaveServiceId: microwaveService.Id,
            status: microwaveService.Status,
            heatingProgram: ServiceHeatingProgramResponse.FromEntity(microwaveService.HeatingProgram));
    }

    public class ServiceHeatingProgramResponse(
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

        public static ServiceHeatingProgramResponse FromEntity(HeatingProgramEntity heatingProgram) => new(
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
