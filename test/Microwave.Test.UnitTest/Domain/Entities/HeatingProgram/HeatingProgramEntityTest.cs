﻿using Microwave.Domain.Entities;
using Microwave.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

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

        [Theory(DisplayName = nameof(ShouldCreateAUserDefinedHeatingProgram))]
        [Trait("Unit/Entities", "HeatingProgram")]
        [InlineData(1, 1)]
        [InlineData(120, 10)]
        [InlineData(100, 5)]
        public void ShouldCreateAUserDefinedHeatingProgram(int seconds, int power)
        {
            var heatingProgram = new HeatingProgramEntity(seconds: seconds, power: power);

            Assert.Equal(seconds, heatingProgram.Seconds);
            Assert.Equal(power, heatingProgram.Power);
        }

        [Fact(DisplayName = nameof(ShouldCreateAQuickstartProgram))]
        [Trait("Unit/Entities", "HeatingProgram")]
        public void ShouldCreateAQuickstartProgram()
        {
            var heatingProgram = new HeatingProgramEntity();

            Assert.Equal(30, heatingProgram.Seconds);
            Assert.Equal(10, heatingProgram.Power);
        }

        [Fact(DisplayName = nameof(ShouldAdd30SecondsIfAddTimeIsCalled))]
        [Trait("Unit/Entities", "HeatingProgram")]
        public void ShouldAdd30SecondsIfAddTimeIsCalled()
        {
            var heatingProgram = new HeatingProgramEntity();
            heatingProgram.AddTime();

            Assert.Equal(60, heatingProgram.Seconds);
            Assert.Equal(10, heatingProgram.Power);
        }

        [Fact(DisplayName = nameof(ShouldThrowActionNotPermittedExceptionIfAddTimeToPredefinedProgram))]
        [Trait("Unit/Entities", "HeatingProgram")]
        public void ShouldThrowActionNotPermittedExceptionIfAddTimeToPredefinedProgram()
        {
            var heatingProgram = new HeatingProgramEntity(
                heatingProgramId: Guid.NewGuid(),
                predefined: true,
                seconds: 30,
                power: 10,
                character: '.',
                name: "default",
                food: "default",
                instructions: "teste");

            var act = () => heatingProgram.AddTime();

            var exception = Assert.Throws<ActionNotPermittedException>(act);
            Assert.Equal("action-not-permitted", exception.Code);
            Assert.Equal("Não é permitido adicionar tempo à programas pré definidos", exception.Message);
        }

        [Fact(DisplayName = nameof(ShoulThrowActionNotPermittedExceptionIfUpdatePredefinedProgram))]
        [Trait("Unit/Entities", "HeatingProgram")]
        public void ShoulThrowActionNotPermittedExceptionIfUpdatePredefinedProgram()
        {
            var heatingProgram = new HeatingProgramEntity(
                heatingProgramId: Guid.NewGuid(),
                predefined: true,
                seconds: 30,
                power: 10,
                character: '.',
                name: "default",
                food: "default",
                instructions: "teste");

            var act = () => heatingProgram.Update(
                seconds: 10,
                power: 5,
                character: 'j',
                name: "new",
                food: "new",
                instructions: "new");

            var exception = Assert.Throws<ActionNotPermittedException>(act);
            Assert.Equal("action-not-permitted", exception.Code);
            Assert.Equal("Não é permitido alterar programas pré definidos", exception.Message);
        }
    }
}
