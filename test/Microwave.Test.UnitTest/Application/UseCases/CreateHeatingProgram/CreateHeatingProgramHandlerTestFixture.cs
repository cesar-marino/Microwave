using Microwave.Application.UseCases.HeatingProgram.CreateHeatingProgram;
using Microwave.Test.UnitTest.Commons;

namespace Microwave.Test.UnitTest.Application.UseCases.CreateHeatingProgram
{
    public class CreateHeatingProgramHandlerTestFixture : FixtureBase
    {
        public CreateHeatingProgramRequest MakeCreateHeatingProgramRequest() => new(
            seconds: Faker.Random.Int(1, 120),
            power: Faker.Random.Int(1, 10),
            character: Faker.Random.Char(),
            name: Faker.Random.String(),
            food: Faker.Random.String(),
            instructions: Faker.Random.String());
    }
}