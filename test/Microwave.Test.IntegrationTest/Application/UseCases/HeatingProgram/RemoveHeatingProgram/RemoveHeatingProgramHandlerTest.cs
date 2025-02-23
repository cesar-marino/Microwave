using Microsoft.EntityFrameworkCore;
using Microwave.Application.UseCases.HeatingProgram.RemoveHeatingProgram;
using Microwave.Domain.Exceptions;
using Microwave.Infrastructure.Data.Contexts;
using Microwave.Infrastructure.Data.Repositories;

namespace Microwave.Test.IntegrationTest.Application.UseCases.HeatingProgram.RemoveHeatingProgram
{
    public class RemoveHeatingProgramHandlerTest(RemoveHeatingProgramHandlerTestFixture fixture) : IClassFixture<RemoveHeatingProgramHandlerTestFixture>
    {
        private readonly RemoveHeatingProgramHandlerTestFixture _fixture = fixture;

        [Fact(DisplayName = nameof(ShouldThrowNotFoundException))]
        [Trait("Integration/UseCase", "HeatingProgram - RemoveHeatingProgram")]
        public async Task ShouldThrowNotFoundException()
        {
            var context = _fixture.MakeMicrowaveContext();
            var unitOfWork = new UnitOfWork(context);
            var repository = new HeatingProgramRepository(context);

            var sut = new RemoveHeatingProgramHandler(
                heatingProgramRepository: repository,
                unitOfWork: unitOfWork);

            var request = _fixture.MakeRemoveHeatingProgramRequest();
            var act = () => sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<NotFoundException>(act);
            Assert.Equal("not-found", exception.Code);
            Assert.Equal("Programa não encontrado", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldRemoveHeatingProgram))]
        [Trait("Integration/UseCase", "HeatingProgram - RemoveHeatingProgram")]
        public async Task ShouldRemoveHeatingProgram()
        {
            var context = _fixture.MakeMicrowaveContext();
            var heatingProgram = _fixture.MakeHeatingProgramEntity();
            await context.HeatingPrograms.AddAsync(heatingProgram);
            await context.SaveChangesAsync();

            var unitOfWork = new UnitOfWork(context);
            var repository = new HeatingProgramRepository(context);

            var sut = new RemoveHeatingProgramHandler(
                heatingProgramRepository: repository,
                unitOfWork: unitOfWork);

            var request = _fixture.MakeRemoveHeatingProgramRequest(heatingProgramId: heatingProgram.Id);
            await sut.Handle(request, _fixture.CancellationToken);

            var ProgramDb = await context.HeatingPrograms.FirstOrDefaultAsync(x => x.Id == heatingProgram.Id);
            Assert.Null(ProgramDb);
        }
    }
}
