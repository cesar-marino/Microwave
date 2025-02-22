using Microwave.Application.UseCases.MicrowaveService.StartService;
using Microwave.Domain.Exceptions;
using Microwave.Domain.Repositories;
using Moq;

namespace Microwave.Test.UnitTest.Application.UseCases.MicrowaveService.StartService
{
    public class StartServiceHandlerTest : IClassFixture<StartServiceHandlerTestFixture>
    {
        private readonly StartServiceHandlerTestFixture _fixture;
        private readonly StartServiceHandler _sut;
        private readonly Mock<IHeatingProgramRepository> _heatingProgramRepositoryMock;

        public StartServiceHandlerTest(StartServiceHandlerTestFixture fixture)
        {
            _fixture = fixture;
            _heatingProgramRepositoryMock = new();

            _sut = new(heatingProgramRepository: _heatingProgramRepositoryMock.Object);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatFindAsyncThrows))]
        [Trait("Unit/UseCase", "MicrowaveService - StartService")]
        public async Task ShouldRethrowSameExceptionThatFindAsyncThrows()
        {
            _heatingProgramRepositoryMock
                .Setup(x => x.FindAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new NotFoundException("Programa de aquecimento não encontrado"));

            var request = _fixture.MakeStartServiceRequest(heatingProgramId: _fixture.Faker.Random.Guid());
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<NotFoundException>(act);
            Assert.Equal("not-found", exception.Code);
            Assert.Equal("Programa de aquecimento não encontrado", exception.Message);
        }
    }
}