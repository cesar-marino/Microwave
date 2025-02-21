using Microwave.Application.UseCases.HeatingProgram.GetListHeatingPrograms;
using Microwave.Test.UnitTest.Commons;

namespace Microwave.Test.UnitTest.Application.UseCases.HeatingProgram.GetListHeatingProgram
{
    public class GetListHeatingProgramsHandlerTestFixture : FixtureBase
    {
        public GetListHeatingProgramsRequest MakeGetListHeatingProgramsRequest() => new();
    }
}
