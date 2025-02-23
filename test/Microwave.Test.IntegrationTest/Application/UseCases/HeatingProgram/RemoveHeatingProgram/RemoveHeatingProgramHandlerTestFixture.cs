using Microwave.Application.UseCases.HeatingProgram.RemoveHeatingProgram;
using Microwave.Test.IntegrationTest.Commons;

namespace Microwave.Test.IntegrationTest.Application.UseCases.HeatingProgram.RemoveHeatingProgram
{
    public class RemoveHeatingProgramHandlerTestFixture : FixtureBase
    {
        public RemoveHeatingProgramRequest MakeRemoveHeatingPRogramRequest(Guid? heatingProgramId = null) =>
            new(heatingProgramId: heatingProgramId ?? Faker.Random.Guid());
    }
}
