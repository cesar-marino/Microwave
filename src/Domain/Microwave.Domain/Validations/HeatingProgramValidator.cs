using FluentValidation;
using Microwave.Domain.Entities;

namespace Microwave.Domain.Validations
{
    public class HeatingProgramValidator : AbstractValidator<HeatingProgramEntity>
    {
        public HeatingProgramValidator()
        {
            RuleFor(x => x.Seconds)
                .GreaterThanOrEqualTo(1).WithMessage("O tempo deve ser maior ou igual à 1 segundo")
                .LessThanOrEqualTo(120).WithMessage("O tempo deve ser menor ou igual a 2 minutos");

            RuleFor(x => x.Power)
                .GreaterThanOrEqualTo(1).WithMessage("A potência deve ser maior ou igual a 1")
                .LessThanOrEqualTo(10).WithMessage("A potência deve ser menor ou igual a 10");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O campo nome não pode ser vazio");

            RuleFor(x => x.Food)
                .NotEmpty().WithMessage("O campo comida não pode ser vazio");
            
            RuleFor(x => x.Character)
                .NotEmpty().WithMessage("O campo character não pode ser vazio");
        }
    }
}
