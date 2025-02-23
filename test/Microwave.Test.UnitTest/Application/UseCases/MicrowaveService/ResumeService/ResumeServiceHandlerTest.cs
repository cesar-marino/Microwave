using Microwave.Application.Services;
using Microwave.Application.UseCases.MicrowaveService.ResumeServivce;
using Microwave.Domain.Exceptions;
using Moq;

namespace Microwave.Test.UnitTest.Application.UseCases.MicrowaveService.ResumeService
{
    public class ResumeServiceHandlerTest : IClassFixture<ResumeServiceHandlerTestFixture>
    {
        private readonly ResumeServiceHandlerTestFixture _fixture;
        private readonly ResumeServiceHandler _sut;
        private readonly Mock<ICountdownBackgroundService> _countdownBackgroundServiceMock;

        public ResumeServiceHandlerTest(ResumeServiceHandlerTestFixture fixture)
        {
            _fixture = fixture;
            _countdownBackgroundServiceMock = new();

            _sut = new(
                countdownService: _countdownBackgroundServiceMock.Object);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatResumeAsyncThrows))]
        [Trait("Unit/UseCase", "MicrowaveService - ResumeService")]
        public async Task ShouldRethrowSameExceptionThatResumeAsyncThrows()
        {
            _countdownBackgroundServiceMock
                .Setup(x => x.ResumeAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new UnexpectedException());

            var request = _fixture.MakeResumeServiceRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<UnexpectedException>(act);
            Assert.Equal("unexpected", exception.Code);
            Assert.Equal("Erro inesperado", exception.Message);
        }
    }
}
