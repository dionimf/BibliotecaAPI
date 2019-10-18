using FluentValidation;
using MF.Domain.Entities;

namespace MF.Domain.Validation
{
    public class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation()
        {
            RuleFor(v => v.PostalCode)
                .NotEmpty().NotNull().WithMessage("O campo CEP deve ser preenchido")
                .MinimumLength(8).MaximumLength(8).WithMessage("O campo CEP não está preenchido corretamente");
            RuleFor(v => v.AddressLine)
                .NotEmpty().NotNull().WithMessage("O campo Endereço deve ser preenchido");
            RuleFor(v => v.City)
                .NotEmpty().NotNull().WithMessage("O campo Cidade deve ser preenchido");
            RuleFor(v => v.State)
                .NotEmpty().NotNull().WithMessage("O campo Estado deve ser preenchido")
                .MinimumLength(2).MaximumLength(2).WithMessage("O campo Estado deve ser preenchido corretamente");
            RuleFor(v => v.Country)
                .NotEmpty().NotNull().WithMessage("O campo País deve ser preenchido")
                .MinimumLength(2).MaximumLength(2).WithMessage("O campo País deve ser preenchido corretamente");
        }
    }
}