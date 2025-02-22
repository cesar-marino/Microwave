using Microwave.Domain.Entities;
using Microwave.Domain.Exceptions;
using System.Threading.Tasks;

namespace Microwave.Test.UnitTest.Domain.Entities.MicrowaveService
{
    public class MicrowaveServiceEntityTest
    {
        [Theory(DisplayName = nameof(ShouldReturnTheCorrectlyProcessedHeatString))]
        [Trait("Unit/Entities", "MicrowaveProgram - Process")]
        [InlineData(1, ".")]
        [InlineData(5, ".....")]
        [InlineData(10, "..........")]
        public void ShouldReturnTheCorrectlyProcessedHeatString(int power, string result)
        {
            var heatingProgram = new HeatingProgramEntity(power: power);
            var microwaveService = new MicrowaveServiceEntity(heatingProgram);

            var response = microwaveService.Process();

            Assert.Equal(result, response);
        }

        [Fact(DisplayName = nameof(ShouldReturnCompletedHeatingAtTheEndOfProcessing))]
        [Trait("Unit/Entities", "MicrowaveProgram - Process")]
        public void ShouldReturnCompletedHeatingAtTheEndOfProcessing()
        {
            var heatingProgram = new HeatingProgramEntity(seconds: 1);
            var microwaveService = new MicrowaveServiceEntity(heatingProgram);

            _ = microwaveService.Process();
            var response = microwaveService.Process();

            Assert.Equal("Aquecimento concluído", response);
            Assert.Equal(0, microwaveService.HeatingProgram.Seconds);
        }

        [Fact(DisplayName = nameof(ShouldThrowActionNotPermittedExceptionIfProgramIsNotInProgress))]
        [Trait("Unit/Entities", "MicrowaveProgram - Stop")]
        public void ShouldThrowActionNotPermittedExceptionIfProgramIsNotInProgress()
        {
            var heatingProgram = new HeatingProgramEntity(seconds: 1);
            var microwaveService = new MicrowaveServiceEntity(heatingProgram);

            microwaveService.Stop();
            microwaveService.Stop();
            var act = () => microwaveService.Stop();

            var exception = Assert.Throws<ActionNotPermittedException>(act);
            Assert.Equal("action-not-permitted", exception.Code);
            Assert.Equal("O programa não esta em andamento", exception.Message);
        }
    }
}
