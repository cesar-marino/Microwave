using Microsoft.EntityFrameworkCore;
using Microwave.Application.UseCases.HeatingProgram.UpdateHeatingProgram;
using Microwave.Domain.Exceptions;
using Microwave.Infrastructure.Data.Contexts;
using Microwave.Infrastructure.Data.Repositories;

namespace Microwave.Test.IntegrationTest.Application.UseCases.HeatingProgram.UpdateHeatingProgram
{
    public class UpdateHeatingProgramHandlerTest(UpdateHeatingProgramHandlerTestFixture fixture) : IClassFixture<UpdateHeatingProgramHandlerTestFixture>
    {
        private readonly UpdateHeatingProgramHandlerTestFixture _fixture = fixture;

        [Fact(DisplayName = nameof(ShouldThroNotFoundException))]
        [Trait("Integration/UseCase", "HeatingProgram - UpdateHeatingProgram")]
        public async Task ShouldThroNotFoundException()
        {
            var context = _fixture.MakeMicrowaveContext();
            var unitOfWork = new UnitOfWork(context);
            var repository = new HeatingProgramRepository(context);

            var sut = new UpdateHeatingProgramHandler(
                heatingProgramRepository: repository,
                unitOfWork: unitOfWork);

            var request = _fixture.MakeUpdateHeatingProgramRequest();
            var act = () => sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<NotFoundException>(act);
            Assert.Equal("not-found", exception.Code);
            Assert.Equal("Programa não encontrado", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldThrowActionNotPermittedExceptionPredefined))]
        [Trait("Integration/UseCase", "HeatingProgram - UpdateHeatingProgram")]
        public async Task ShouldThrowActionNotPermittedExceptionPredefined()
        {
            var context = _fixture.MakeMicrowaveContext();
            var heatingProgram = _fixture.MakeHeatingProgramEntity(predefined: true);
            await context.HeatingPrograms.AddAsync(heatingProgram);
            await context.SaveChangesAsync();

            var unitOfWork = new UnitOfWork(context);
            var repository = new HeatingProgramRepository(context);

            var sut = new UpdateHeatingProgramHandler(
                heatingProgramRepository: repository,
                unitOfWork: unitOfWork);

            var request = _fixture.MakeUpdateHeatingProgramRequest(heatingProgramId: heatingProgram.Id);
            var act = () => sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<ActionNotPermittedException>(act);
            Assert.Equal("action-not-permitted", exception.Code);
            Assert.Equal("Não é permitido alterar um programa predefinido", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldThrowActionNotPermittedException))]
        [Trait("Integration/UseCase", "HeatingProgram - UpdateHeatingProgram")]
        public async Task ShouldThrowActionNotPermittedException()
        {
            var context = _fixture.MakeMicrowaveContext();
            var heatingProgram = _fixture.MakeHeatingProgramEntity();
            await context.HeatingPrograms.AddAsync(heatingProgram);
            await context.SaveChangesAsync();

            var unitOfWork = new UnitOfWork(context);
            var repository = new HeatingProgramRepository(context);

            var sut = new UpdateHeatingProgramHandler(
                heatingProgramRepository: repository,
                unitOfWork: unitOfWork);

            var request = _fixture.MakeUpdateHeatingProgramRequest(
                heatingProgramId: heatingProgram.Id,
                character: heatingProgram.Character);

            var act = () => sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<ActionNotPermittedException>(act);
            Assert.Equal("action-not-permitted", exception.Code);
            Assert.Equal("Caractere de aquecimento em uso", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldUpdateHeatingProgram))]
        [Trait("Integration/UseCase", "HeatingProgram - UpdateHeatingProgram")]
        public async Task ShouldUpdateHeatingProgram()
        {
            var context = _fixture.MakeMicrowaveContext();
            var heatingProgram = _fixture.MakeHeatingProgramEntity();
            await context.HeatingPrograms.AddAsync(heatingProgram);
            await context.SaveChangesAsync();

            var unitOfWork = new UnitOfWork(context);
            var repository = new HeatingProgramRepository(context);

            var sut = new UpdateHeatingProgramHandler(
                heatingProgramRepository: repository,
                unitOfWork: unitOfWork);

            var request = _fixture.MakeUpdateHeatingProgramRequest(heatingProgramId: heatingProgram.Id);
            var response = await sut.Handle(request, _fixture.CancellationToken);

            Assert.False(response.Predefined);
            Assert.Equal(request.Character, response.Character);
            Assert.Equal(request.Food, response.Food);
            Assert.Equal(request.HeatingProgramId, response.HeatingProgramId);
            Assert.Equal(request.Instructions, response.Instructions);
            Assert.Equal(request.Name, response.Name);
            Assert.Equal(request.Power, response.Power);
            Assert.Equal(request.Seconds, response.Seconds);

            var programDb = await context.HeatingPrograms.FirstOrDefaultAsync(x => x.Id == heatingProgram.Id);
            Assert.Equal(request.Character, programDb?.Character);
            Assert.Equal(request.Food, programDb?.Food);
            Assert.Equal(request.HeatingProgramId, programDb?.Id);
            Assert.Equal(request.Instructions, programDb?.Instructions);
            Assert.Equal(request.Name, programDb?.Name);
            Assert.Equal(request.Power, programDb?.Power);
            Assert.Equal(request.Seconds, programDb?.Seconds);
        }
    }
}
