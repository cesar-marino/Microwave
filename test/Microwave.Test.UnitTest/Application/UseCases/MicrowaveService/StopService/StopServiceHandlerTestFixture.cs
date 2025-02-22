using Microwave.Application.UseCases.MicrowaveService.StopService;
using Microwave.Test.UnitTest.Commons;

namespace Microwave.Test.UnitTest.Application.UseCases.MicrowaveService.StopService
{
    public class StopServiceHandlerTestFixture : FixtureBase
    {
        public StopServiceRequest MakeStopServiceRequest() => new(microwaveServiceId: Faker.Random.Guid());
    }
}
