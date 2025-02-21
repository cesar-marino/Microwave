using Microwave.Application.UseCases.HeatingProgram.GetListHeatingPrograms;
using Microwave.Domain.Exceptions;
using Microwave.Domain.Repositories;
using Moq;

namespace Microwave.Test.UnitTest.Application.UseCases.HeatingProgram.GetListHeatingProgram
{
    public class GetListHeatingProgramsHandlerTest : IClassFixture<GetListHeatingProgramsHandlerTestFixture>
    {
        private readonly GetListHeatingProgramsHandlerTestFixture _fixture;
        private readonly GetListHeatingProgramsHandler _sut;
        private readonly Mock<IHeatingProgramRepository> _heatingProgramRepositoryMock;

        public GetListHeatingProgramsHandlerTest(GetListHeatingProgramsHandlerTestFixture fixture)
        {
            _fixture = fixture;
            _heatingProgramRepositoryMock = new();

            _sut = new(heatingProgramRepository: _heatingProgramRepositoryMock.Object);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatGetAllAsyncThrows))]
        [Trait("Unit/UseCase", "HeatingProgram - GetListHeatingPrograms")]
        public async Task ShouldRethrowSameExceptionThatGetAllAsyncThrows()
        {
            _heatingProgramRepositoryMock
                .Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new UnexpectedException());

            var request = _fixture.MakeGetListHeatingProgramsRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<UnexpectedException>(act);
            Assert.Equal("unexpected", exception.Code);
            Assert.Equal("Erro inesperado", exception.Message);
        }
    }
}
