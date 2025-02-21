using Microwave.Application.UseCases.HeatingProgram.RemoveHeatingProgram;
using Microwave.Test.UnitTest.Commons;

namespace Microwave.Test.UnitTest.Application.UseCases.HeatingProgram.RemoveHeatingProgram
{
    public class RemoveHeatingProgramHandlerTestFixture : FixtureBase
    {
        public RemoveHeatingProgramRequest MakeRemoveHeatingProgramRequest() => new(heatingProgramId: Faker.Random.Guid());
    }
}
