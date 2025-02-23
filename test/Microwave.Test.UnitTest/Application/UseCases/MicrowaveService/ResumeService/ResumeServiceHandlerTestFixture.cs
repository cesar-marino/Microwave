using Microwave.Application.UseCases.MicrowaveService.ResumeServivce;
using Microwave.Test.UnitTest.Commons;

namespace Microwave.Test.UnitTest.Application.UseCases.MicrowaveService.ResumeService
{
    public class ResumeServiceHandlerTestFixture : FixtureBase
    {
        public ResumeServiceRequest MakeResumeServiceRequest() => new(microwaveServiceId: Faker.Random.Guid());
    }
}
