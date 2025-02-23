namespace Microwave.Test.IntegrationTest.Application.UseCases.HeatingProgram.GetListHeatingPrograms
{
    public class GetListHeatingProgramsHandlerTest : IClassFixture<GetListHeatingProgramsHandlerTestFixture>
    {
        [Fact(DisplayName = nameof(ShouldReturnSameResultThatGetAllAsync))]
        [Trait("Integration/UseCase", "HeatingProgram - GetListHeatingPrograms")]
        public async Task ShouldReturnSameResultThatGetAllAsync()
        {

        }
    }
}
