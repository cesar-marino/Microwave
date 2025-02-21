using Microwave.Application.UseCases.HeatingProgram.UpdateHeatingProgram;
using Microwave.Domain.Entities;
using Microwave.Domain.Exceptions;
using Microwave.Domain.Repositories;
using Microwave.Domain.SeedWork;
using Moq;

namespace Microwave.Test.UnitTest.Application.UseCases.HeatingProgram.UpdateHeatingProgram
{
    public class UpdateHeatingProgramHandlerTest : IClassFixture<UpdateHeatingProgramHandlerTestFixture>
    {
        private readonly UpdateHeatingProgramHandlerTestFixture _fixture;
        private readonly UpdateHeatingProgramHandler _sut;
        private readonly Mock<IHeatingProgramRepository> _heatingProgramRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public UpdateHeatingProgramHandlerTest(UpdateHeatingProgramHandlerTestFixture fixture)
        {
            _fixture = fixture;
            _heatingProgramRepositoryMock = new();
            _unitOfWorkMock = new();

            _sut = new(
                heatingProgramRepository: _heatingProgramRepositoryMock.Object,
                unitOfWork: _unitOfWorkMock.Object);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatFindAsyncThrows))]
        [Trait("Unit/UseCase", "HeatingProgram - UpdateHeatingProgram")]
        public async Task ShouldRethrowSameExceptionThatFindAsyncThrows()
        {
            _heatingProgramRepositoryMock
                .Setup(x => x.FindAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new NotFoundException(message: "Programa de aquecimento não encontrado"));

            var request = _fixture.MakeUpdateHeatingProgramRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<NotFoundException>(act);
            Assert.Equal("not-found", exception.Code);
            Assert.Equal("Programa de aquecimento não encontrado", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldThrowActionNotPermittedExceptionIfProgramIsPredefined))]
        [Trait("Unit/UseCase", "HeatingProgram - UpdateHeatingProgram")]
        public async Task ShouldThrowActionNotPermittedExceptionIfProgramIsPredefined()
        {
            var heatingProgram = _fixture.MakeHeatingProgramEntity(predefined: true);
            _heatingProgramRepositoryMock
                .Setup(x => x.FindAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(heatingProgram);

            var request = _fixture.MakeUpdateHeatingProgramRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<ActionNotPermittedException>(act);
            Assert.Equal("action-not-permitted", exception.Code);
            Assert.Equal("Não é permitido alterar um programa predefinido", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatCheckCharacterAsyncThrows))]
        [Trait("Unit/UseCase", "HeatingProgram - UpdateHeatingProgram")]
        public async Task ShouldRethrowSameExceptionThatCheckCharacterAsyncThrows()
        {
            var heatingProgram = _fixture.MakeHeatingProgramEntity();
            _heatingProgramRepositoryMock
                .Setup(x => x.FindAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(heatingProgram);

            _heatingProgramRepositoryMock
                .Setup(x => x.CheckCharacterAsync(
                    It.IsAny<char>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new UnexpectedException());

            var request = _fixture.MakeUpdateHeatingProgramRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<UnexpectedException>(act);
            Assert.Equal("unexpected", exception.Code);
            Assert.Equal("Erro inesperado", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldThrowActionNotPermittedExceptionIfCheckCharacterAsyncReturnsTrue))]
        [Trait("Unit/UseCase", "HeatingProgram - UpdateHeatingProgram")]
        public async Task ShouldThrowActionNotPermittedExceptionIfCheckCharacterAsyncReturnsTrue()
        {
            var heatingProgram = _fixture.MakeHeatingProgramEntity();
            _heatingProgramRepositoryMock
                .Setup(x => x.FindAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(heatingProgram);

            _heatingProgramRepositoryMock
                .Setup(x => x.CheckCharacterAsync(
                    It.IsAny<char>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var request = _fixture.MakeUpdateHeatingProgramRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<ActionNotPermittedException>(act);
            Assert.Equal("action-not-permitted", exception.Code);
            Assert.Equal("Caractere de aquecimento em uso", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldThrowActionNotPermittedExceptionIfCharacterIsDefault))]
        [Trait("Unit/UseCase", "HeatingProgram - UpdateHeatingProgram")]
        public async Task ShouldThrowActionNotPermittedExceptionIfCharacterIsDefault()
        {
            var heatingProgram = _fixture.MakeHeatingProgramEntity();
            _heatingProgramRepositoryMock
                .Setup(x => x.FindAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(heatingProgram);

            _heatingProgramRepositoryMock
                .Setup(x => x.CheckCharacterAsync(
                    It.IsAny<char>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            _heatingProgramRepositoryMock
                .Setup(x => x.CheckCharacterAsync(
                    It.IsAny<char>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var request = _fixture.MakeUpdateHeatingProgramRequest(character: '.');
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<ActionNotPermittedException>(act);
            Assert.Equal("action-not-permitted", exception.Code);
            Assert.Equal("Caractere de aquecimento em uso", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatUpdateAsyncThrows))]
        [Trait("Unit/UseCase", "HeatingProgram - UpdateHeatingProgram")]
        public async Task ShouldRethrowSameExceptionThatUpdateAsyncThrows()
        {
            var heatingProgram = _fixture.MakeHeatingProgramEntity();
            _heatingProgramRepositoryMock
                .Setup(x => x.FindAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(heatingProgram);

            _heatingProgramRepositoryMock
                .Setup(x => x.CheckCharacterAsync(
                    It.IsAny<char>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            _heatingProgramRepositoryMock
                .Setup(x => x.UpdateAsync(
                    It.IsAny<HeatingProgramEntity>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new UnexpectedException());

            var request = _fixture.MakeUpdateHeatingProgramRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<UnexpectedException>(act);
            Assert.Equal("unexpected", exception.Code);
            Assert.Equal("Erro inesperado", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatCommitAsyncThrows))]
        [Trait("Unit/UseCase", "HeatingProgram - UpdateHeatingProgram")]
        public async Task ShouldRethrowSameExceptionThatCommitAsyncThrows()
        {
            var heatingProgram = _fixture.MakeHeatingProgramEntity();
            _heatingProgramRepositoryMock
                .Setup(x => x.FindAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(heatingProgram);

            _heatingProgramRepositoryMock
                .Setup(x => x.CheckCharacterAsync(
                    It.IsAny<char>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            _unitOfWorkMock
                .Setup(x => x.CommitAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new UnexpectedException());

            var request = _fixture.MakeUpdateHeatingProgramRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<UnexpectedException>(act);
            Assert.Equal("unexpected", exception.Code);
            Assert.Equal("Erro inesperado", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldReturnTheCorrectResponseIfHeatingProgramIsSuccessfullyUpdated))]
        [Trait("Unit/UseCase", "HeatingProgram - UpdateHeatingProgram")]
        public async Task ShouldReturnTheCorrectResponseIfHeatingProgramIsSuccessfullyUpdated()
        {
            var heatingProgram = _fixture.MakeHeatingProgramEntity();
            _heatingProgramRepositoryMock
                .Setup(x => x.FindAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(heatingProgram);

            _heatingProgramRepositoryMock
                .Setup(x => x.CheckCharacterAsync(
                    It.IsAny<char>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var request = _fixture.MakeUpdateHeatingProgramRequest(heatingProgramId: heatingProgram.Id);
            var response = await _sut.Handle(request, _fixture.CancellationToken);

            Assert.Equal(request.Character, response.Character);
            Assert.Equal(request.Food, response.Food);
            Assert.Equal(request.HeatingProgramId, response.HeatingProgramId);
            Assert.Equal(request.Instructions, response.Instructions);
            Assert.Equal(request.Name, response.Name);
            Assert.Equal(request.Power, response.Power);
            Assert.Equal(request.Seconds, response.Seconds);
        }
    }
}
