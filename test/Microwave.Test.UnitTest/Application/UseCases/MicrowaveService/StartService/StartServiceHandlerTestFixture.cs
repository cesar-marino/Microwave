using Microwave.Application.UseCases.MicrowaveService.StartService;
using Microwave.Test.UnitTest.Commons;

namespace Microwave.Test.UnitTest.Application.UseCases.MicrowaveService.StartService
{
    public class StartServiceHandlerTestFixture : FixtureBase
    {
        public StartServiceRequest MakeStartServiceRequest(
            Guid? heatingProgramId = null,
            int? seconds = null,
            int? power = null) => new(
                heatingProgramId: heatingProgramId,
                seconds: seconds,
                power: power);
    }
}
