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
    }
}
