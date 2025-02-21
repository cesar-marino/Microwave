using Microwave.Application.UseCases.HeatingProgram.RemoveHeatingProgram;
using Microwave.Domain.Exceptions;
using Microwave.Domain.Repositories;
using Moq;

namespace Microwave.Test.UnitTest.Application.UseCases.HeatingProgram.RemoveHeatingProgram
{
    public class RemoveHeatingProgramHandlerTest : IClassFixture<RemoveHeatingProgramHandlerTestFixture>
    {
        private readonly RemoveHeatingProgramHandlerTestFixture _fixture;
        private readonly RemoveHeatingProgramHandler _sut;
        private readonly Mock<IHeatingProgramRepository> _heatingProgramRepositoryMock;

        public RemoveHeatingProgramHandlerTest(RemoveHeatingProgramHandlerTestFixture fixture)
        {
            _fixture = fixture;
            _heatingProgramRepositoryMock = new();

            _sut = new(heatingProgramRepository: _heatingProgramRepositoryMock.Object);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatFindAsyncThrows))]
        [Trait("Unit/UseCase", "HeatingProgram - RemoveHeatingProgram")]
        public async Task ShouldRethrowSameExceptionThatFindAsyncThrows()
        {
            _heatingProgramRepositoryMock
                .Setup(x => x.FindAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new NotFoundException(message: "Programa de aquecimento não encontrado"));

            var request = _fixture.MakeRemoveHeatingProgramRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<NotFoundException>(act);
            Assert.Equal("not-found", exception.Code);
            Assert.Equal("Programa de aquecimento não encontrado", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldThrowActionNotPermittedExceptionIfHeatingProgramIsPredefined))]
        [Trait("Unit/UseCase", "HeatingProgram - RemoveHeatingProgram")]
        public async Task ShouldThrowActionNotPermittedExceptionIfHeatingProgramIsPredefined()
        {
            var heatingProgram = _fixture.MakeHeatingProgramEntity(predefined: true);
            _heatingProgramRepositoryMock
                .Setup(x => x.FindAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(heatingProgram);

            var request = _fixture.MakeRemoveHeatingProgramRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<ActionNotPermittedException>(act);
            Assert.Equal("action-not-permitted", exception.Code);
            Assert.Equal("Não é permitido excluir um programa predefinido", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldThrowActionNotPermittedExceptionIfHeatingProgramIsPredefined))]
        [Trait("Unit/UseCase", "HeatingProgram - RemoveHeatingProgram")]
        public async Task ShouldRethrowSameExceptionThatRemoveAsyncThrows()
        {
            var heatingProgram = _fixture.MakeHeatingProgramEntity();
            _heatingProgramRepositoryMock
                .Setup(x => x.FindAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(heatingProgram);

            _heatingProgramRepositoryMock
                .Setup(x => x.RemoveAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new UnexpectedException());

            var request = _fixture.MakeRemoveHeatingProgramRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<UnexpectedException>(act);
            Assert.Equal("unexpected", exception.Code);
            Assert.Equal("Erro inexperado", exception.Message);
        }
    }
}
