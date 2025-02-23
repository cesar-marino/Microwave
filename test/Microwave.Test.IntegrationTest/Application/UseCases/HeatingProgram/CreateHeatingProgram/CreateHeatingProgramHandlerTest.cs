using Microsoft.EntityFrameworkCore;
using Microwave.Application.UseCases.HeatingProgram.CreateHeatingProgram;
using Microwave.Domain.Exceptions;
using Microwave.Infrastructure.Data.Repositories;

namespace Microwave.Test.IntegrationTest.Application.UseCases.HeatingProgram.CreateHeatingProgram
{
    public class CreateHeatingProgramHandlerTest(CreateHeatingProgramHandlerTestFixture fixture) : IClassFixture<CreateHeatingProgramHandlerTestFixture>
    {
        private readonly CreateHeatingProgramHandlerTestFixture _fixture = fixture;

        [Fact(DisplayName = nameof(ShouldThrowActionNotPermittedException))]
        [Trait("Integration/UseCase", "HeatingProgram - CreateHeatingProgram")]
        public async Task ShouldThrowActionNotPermittedException()
        {
            var context = _fixture.MakeMicrowaveContext();
            var heatingProgram = _fixture.MakeHeatingProgramEntity();
            var trackingInfo = await context.HeatingPrograms.AddAsync(heatingProgram);
            await context.SaveChangesAsync();
            trackingInfo.State = EntityState.Detached;

            var repository = new HeatingProgramRepository(context);
            var sut = new CreateHeatingProgramHandler(
                heatingProgramRepository: repository,
                unitOfWork: context);

            var request = _fixture.MakeCreateHeatingProgramRequest(character: heatingProgram.Character);
            var act = () => sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<ActionNotPermittedException>(act);
            Assert.Equal("action-not-permitted", exception.Code);
            Assert.Equal("Caractere de aquecimento em uso", exception.Message);
        }
    }
}
