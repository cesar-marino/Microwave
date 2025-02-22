using Microwave.Domain.Entities;

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
    }
}
