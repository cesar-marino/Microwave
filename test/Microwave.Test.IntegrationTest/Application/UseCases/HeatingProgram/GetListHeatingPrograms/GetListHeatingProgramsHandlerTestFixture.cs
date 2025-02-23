using Microwave.Application.UseCases.HeatingProgram.GetListHeatingPrograms;
using Microwave.Test.IntegrationTest.Commons;

namespace Microwave.Test.IntegrationTest.Application.UseCases.HeatingProgram.GetListHeatingPrograms
{
    public class GetListHeatingProgramsHandlerTestFixture : FixtureBase
    {
        public GetListHeatingProgramsRequest MakeGetListHeatingPrograms() => new();
    }
}
