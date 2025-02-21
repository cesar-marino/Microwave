using Microwave.Application.UseCases.HeatingProgram.CreateHeatingProgram;
using Microwave.Domain.Entities;
using Microwave.Domain.Exceptions;
using Microwave.Domain.Repositories;
using Microwave.Domain.SeedWork;
using Moq;

namespace Microwave.Test.UnitTest.Application.UseCases.CreateHeatingProgram
{
    public class CreateHeatingProgramHandlerTest : IClassFixture<CreateHeatingProgramHandlerTestFixture>
    {
        private readonly CreateHeatingProgramHandlerTestFixture _fixture;
        private readonly CreateHeatingProgramHandler _sut;
        private readonly Mock<IHeatingProgramRepository> _heatingProgramRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public CreateHeatingProgramHandlerTest(CreateHeatingProgramHandlerTestFixture fixture)
        {
            _fixture = fixture;
            _heatingProgramRepositoryMock = new();
            _unitOfWorkMock = new();

            _sut = new(
                heatingProgramRepository: _heatingProgramRepositoryMock.Object,
                unitOfWork: _unitOfWorkMock.Object);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatCheckCharacterAsyncThrows))]
        [Trait("Unit/UseCases", "HeatingProgram - CreateHeatingProgram")]
        public async Task ShouldRethrowSameExceptionThatCheckCharacterAsyncThrows()
        {
            _heatingProgramRepositoryMock
                .Setup(x => x.CheckCharacterAsync(
                    It.IsAny<char>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new UnexpectedException());

            var request = _fixture.MakeCreateHeatingProgramRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<UnexpectedException>(act);
            Assert.Equal("unexpected", exception.Code);
            Assert.Equal("Erro inexperado", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldThrowActionNotPermittedExceptionIfCheckCharacterAsyncReturnsTrue))]
        [Trait("Unit/UseCases", "HeatingProgram - CreateHeatingProgram")]
        public async Task ShouldThrowActionNotPermittedExceptionIfCheckCharacterAsyncReturnsTrue()
        {
            _heatingProgramRepositoryMock
                .Setup(x => x.CheckCharacterAsync(
                    It.IsAny<char>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var request = _fixture.MakeCreateHeatingProgramRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<ActionNotPermittedException>(act);
            Assert.Equal("action-not-permitted", exception.Code);
            Assert.Equal("Caractere de aquecimento em uso", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatInsertAsyncThrows))]
        [Trait("Unit/UseCases", "HeatingProgram - CreateHeatingProgram")]
        public async Task ShouldRethrowSameExceptionThatInsertAsyncThrows()
        {
            _heatingProgramRepositoryMock
                .Setup(x => x.CheckCharacterAsync(
                    It.IsAny<char>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            _heatingProgramRepositoryMock
                .Setup(x => x.InsertAsync(
                    It.IsAny<HeatingProgramEntity>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new UnexpectedException());

            var request = _fixture.MakeCreateHeatingProgramRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<UnexpectedException>(act);
            Assert.Equal("unexpected", exception.Code);
            Assert.Equal("Erro inexperado", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatCommitAsyncThrows))]
        [Trait("Unit/UseCases", "HeatingProgram - CreateHeatingProgram")]
        public async Task ShouldRethrowSameExceptionThatCommitAsyncThrows()
        {
            _heatingProgramRepositoryMock
                .Setup(x => x.CheckCharacterAsync(
                    It.IsAny<char>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            _unitOfWorkMock
                .Setup(x => x.CommitAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new UnexpectedException());

            var request = _fixture.MakeCreateHeatingProgramRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<UnexpectedException>(act);
            Assert.Equal("unexpected", exception.Code);
            Assert.Equal("Erro inexperado", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldReturnTheCorrectResponseIfHeatingProgramIsSuccessfullyAdded))]
        [Trait("Unit/UseCases", "HeatingProgram - CreateHeatingProgram")]
        public async Task ShouldReturnTheCorrectResponseIfHeatingProgramIsSuccessfullyAdded()
        {
            _heatingProgramRepositoryMock
                .Setup(x => x.CheckCharacterAsync(
                    It.IsAny<char>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var request = _fixture.MakeCreateHeatingProgramRequest();
            var response = await _sut.Handle(request, _fixture.CancellationToken);

            Assert.Equal(request.Character, response.Character);
            Assert.Equal(request.Food, response.Food);
            Assert.Equal(request.Instructions, response.Instructions);
            Assert.Equal(request.Name, response.Name);
            Assert.Equal(request.Power, response.Power);
            Assert.Equal(request.Seconds, response.Seconds);
        }
    }
}
