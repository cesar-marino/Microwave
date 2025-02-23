using Microwave.Application.UseCases.HeatingProgram.UpdateHeatingProgram;
using Microwave.Test.IntegrationTest.Commons;

namespace Microwave.Test.IntegrationTest.Application.UseCases.HeatingProgram.UpdateHeatingProgram
{
    public class UpdateHeatingProgramHandlerTestFixture : FixtureBase
    {
        public UpdateHeatingProgramRequest MakeUpdateHeatingProgramRequest(
            Guid? heatingProgramId = null,
            char? character = null) => new(
                heatingProgramId: heatingProgramId ?? Faker.Random.Guid(),
                seconds: Faker.Random.Int(1, 120),
                power: Faker.Random.Int(1, 10),
                character: character ?? Faker.Random.Char(),
                name: Faker.Random.String(),
                food: Faker.Random.String(),
                instructions: Faker.Random.String());
    }
}
