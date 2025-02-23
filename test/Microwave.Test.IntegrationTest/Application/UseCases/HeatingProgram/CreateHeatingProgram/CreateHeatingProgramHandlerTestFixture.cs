using Microwave.Application.UseCases.HeatingProgram.CreateHeatingProgram;
using Microwave.Test.IntegrationTest.Commons;

namespace Microwave.Test.IntegrationTest.Application.UseCases.HeatingProgram.CreateHeatingProgram
{
    public class CreateHeatingProgramHandlerTestFixture : FixtureBase
    {
        public CreateHeatingProgramRequest MakeCreateHeatingProgramRequest(char? character = null) => new(
            seconds: Faker.Random.Int(1, 120),
            power: Faker.Random.Int(1, 10),
            character: character ?? Faker.Random.Char(),
            name: Faker.Random.String(),
            food: Faker.Random.String(),
            instructions: Faker.Random.String());
    }
}
