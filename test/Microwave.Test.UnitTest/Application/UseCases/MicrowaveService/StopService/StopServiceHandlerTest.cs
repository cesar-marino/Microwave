using Microwave.Application.Services;
using Microwave.Application.UseCases.MicrowaveService.StopService;
using Microwave.Domain.Entities;
using Microwave.Domain.Enums;
using Microwave.Domain.Exceptions;
using Moq;

namespace Microwave.Test.UnitTest.Application.UseCases.MicrowaveService.StopService
{
    public class StopServiceHandlerTest : IClassFixture<StopServiceHandlerTestFixture>
    {
        private readonly StopServiceHandlerTestFixture _fixture;
        private readonly StopServiceHandler _sut;
        private readonly Mock<ICountdownBackgroundService> _countdownServiceMock;

        public StopServiceHandlerTest(StopServiceHandlerTestFixture fixture)
        {
            _fixture = fixture;
            _countdownServiceMock = new();

            _sut = new(countdownService: _countdownServiceMock.Object);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatStopAsyncThrows))]
        [Trait("Unit/UseCase", "MicrowaveService - StopService")]
        public async Task ShouldRethrowSameExceptionThatStopAsyncThrows()
        {
            _countdownServiceMock
                .Setup(x => x.StopAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new NotFoundException("Serviço não encontrado"));

            var request = _fixture.MakeStopServiceRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<NotFoundException>(act);
            Assert.Equal("not-found", exception.Code);
            Assert.Equal("Serviço não encontrado", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldReturnTheCorrectResponseIfServiceIsSuccessfullyStoped))]
        [Trait("Unit/UseCase", "MicrowaveService - StopService")]
        public async Task ShouldReturnTheCorrectResponseIfServiceIsSuccessfullyStoped()
        {
            var microwaveService = _fixture.MakeMicrowaveServiceEntity(new HeatingProgramEntity());
            microwaveService.Stop();

            _countdownServiceMock
                .Setup(x => x.StopAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(microwaveService);

            var request = _fixture.MakeStopServiceRequest();
            var response = await _sut.Handle(request, _fixture.CancellationToken);

            Assert.NotNull(response);
            Assert.Equal(MicrowaveServiceStatus.Paused, response.Status);
        }
    }
}
