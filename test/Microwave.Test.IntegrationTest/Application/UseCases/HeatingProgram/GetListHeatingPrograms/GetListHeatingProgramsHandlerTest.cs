using Microwave.Application.UseCases.HeatingProgram.GetListHeatingPrograms;
using Microwave.Infrastructure.Data.Repositories;

namespace Microwave.Test.IntegrationTest.Application.UseCases.HeatingProgram.GetListHeatingPrograms
{
    public class GetListHeatingProgramsHandlerTest(GetListHeatingProgramsHandlerTestFixture fixture) : IClassFixture<GetListHeatingProgramsHandlerTestFixture>
    {
        private readonly GetListHeatingProgramsHandlerTestFixture _fixture = fixture;

        [Fact(DisplayName = nameof(ShouldReturnEmptyList))]
        [Trait("Integration/UseCase", "HeatingProgram - GetListHeatingPrograms")]
        public async Task ShouldReturnEmptyList()
        {
            var context = _fixture.MakeMicrowaveContext();
            var repository = new HeatingProgramRepository(context);
            var sut = new GetListHeatingProgramsHandler(heatingProgramRepository: repository);

            var request = _fixture.MakeGetListHeatingPrograms();
            var response = await sut.Handle(request, _fixture.CancellationToken);

            Assert.Empty(response);
        }
    }
}
