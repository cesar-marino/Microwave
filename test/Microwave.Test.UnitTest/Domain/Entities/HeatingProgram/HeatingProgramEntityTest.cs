using Microwave.Domain.Entities;
using Microwave.Domain.Exceptions;

namespace Microwave.Test.UnitTest.Domain.Entities.HeatingProgram
{
    public class HeatingProgramEntityTest
    {
        [Theory(DisplayName = nameof(ShouldThrowEntityValidationExceptionIfSecondsIsInvalid))]
        [Trait("Unit/Entities", "HeatingProgram")]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(121)]
        public void ShouldThrowEntityValidationExceptionIfSecondsIsInvalid(int seconds)
        {
            var act = () => new HeatingProgramEntity(seconds: seconds);

            var exception = Assert.Throws<EntityValidationException>(act);
            Assert.Equal("entity-validation", exception.Code);
            Assert.Equal("Tempo inválido", exception.Message);
        }

        [Theory(DisplayName = nameof(ShouldThrowEntityValidationExceptionIfPowerIsInvalid))]
        [Trait("Unit/Entities", "HeatingProgram")]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(11)]
        public void ShouldThrowEntityValidationExceptionIfPowerIsInvalid(int power)
        {
            var act = () => new HeatingProgramEntity(power: power);

            var exception = Assert.Throws<EntityValidationException>(act);
            Assert.Equal("entity-validation", exception.Code);
            Assert.Equal("Potência inválida", exception.Message);
        }
    }
}
