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

        [Fact(DisplayName = nameof(ShouldReturnCorrectList))]
        [Trait("Integration/UseCase", "HeatingProgram - GetListHeatingPrograms")]
        public async Task ShouldReturnCorrectList()
        {
            var context = _fixture.MakeMicrowaveContext();
            var list = _fixture.MakeListHeatingPrograms();
            await context.HeatingPrograms.AddRangeAsync(list);
            await context.SaveChangesAsync();

            var repository = new HeatingProgramRepository(context);
            var sut = new GetListHeatingProgramsHandler(heatingProgramRepository: repository);

            var request = _fixture.MakeGetListHeatingPrograms();
            var response = await sut.Handle(request, _fixture.CancellationToken);

            Assert.Equal(list.Count, response.Count);
            list.ForEach((item) =>
            {
                var r = response.FirstOrDefault(x => x.HeatingProgramId == item.Id);
                Assert.NotNull(r);
                Assert.Equal(item.Character, r.Character);
                Assert.Equal(item.Food, r.Food);
                Assert.Equal(item.Id, r.HeatingProgramId);
                Assert.Equal(item.Instructions, r.Instructions);
                Assert.Equal(item.Name, r.Name);
                Assert.Equal(item.Power, r.Power);
                Assert.Equal(item.Predefined, r.Predefined);
                Assert.Equal(item.Seconds, r.Seconds);
            });
        }
    }
}
