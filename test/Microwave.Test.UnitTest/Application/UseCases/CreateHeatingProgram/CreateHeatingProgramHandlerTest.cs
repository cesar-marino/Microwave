using Microwave.Application.UseCases.HeatingProgram.CreateHeatingProgram;
using Microwave.Domain.Entities;
using Microwave.Domain.Exceptions;
using Microwave.Domain.Repositories;
using Moq;

namespace Microwave.Test.UnitTest.Application.UseCases.CreateHeatingProgram
{
    public class CreateHeatingProgramHandlerTest : IClassFixture<CreateHeatingProgramHandlerTestFixture>
    {
        private readonly CreateHeatingProgramHandlerTestFixture _fixture;
        private readonly CreateHeatingProgramHandler _sut;
        private readonly Mock<IHeatingProgramRepository> _heatingProgramRepositoryMock;

        public CreateHeatingProgramHandlerTest(CreateHeatingProgramHandlerTestFixture fixture)
        {
            _fixture = fixture;
            _heatingProgramRepositoryMock = new();

            _sut = new(
                heatingProgramRepository: _heatingProgramRepositoryMock.Object);
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
    }
}
