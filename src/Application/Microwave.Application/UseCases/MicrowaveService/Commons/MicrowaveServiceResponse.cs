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

        public static MicrowaveServiceResponse FromEntity(
            MicrowaveServiceEntity microwaveService,
            HeatingProgramEntity? heatingProgram = null)
        {
            return new MicrowaveServiceResponse(
                microwaveServiceId: microwaveService.Id,
                status: microwaveService.Status,
                heatingProgram: heatingProgram != null
                    ? ServiceHeatingProgramResponse.FromEntity(heatingProgram)
                    : ServiceHeatingProgramResponse.FromEntity(microwaveService.HeatingProgram));
        }
    }

    public class ServiceHeatingProgramResponse(
        int seconds,
        int power,
        string name,
        string food,
        char character,
        string? instructions)
    {
        public int Seconds { get; } = seconds;
        public int Power { get; } = power;
        public string Name { get; } = name;
        public string Food { get; } = food;
        public char Character { get; } = character;
        public string? Instructions { get; } = instructions;

        public static ServiceHeatingProgramResponse FromEntity(HeatingProgramEntity heatingProgram) => new(
            seconds: heatingProgram.Seconds,
            power: heatingProgram.Power,
            name: heatingProgram.Name,
            food: heatingProgram.Food,
            character: heatingProgram.Character,
            instructions: heatingProgram.Instructions);
    }
}
