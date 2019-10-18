using FluentValidation;
using MF.Domain.Entities;

namespace MF.Domain.Validation
{
    public class ContactValidation : AbstractValidator<Contact>
    {
        public ContactValidation()
        {
            RuleFor(v => v.PhoneNumber)
                .NotEmpty().NotNull().WithMessage("O campo Celular deve ser preenchido.")
                .MinimumLength(8).WithMessage("O campo Celular não está preenchido corretamente")
                .MaximumLength(15).WithMessage("O campo Celular não está preenchido corretamente");
            RuleFor(v=>v.Email)
                .EmailAddress().WithMessage("O campo Email deve ser valido.")
                .NotEmpty().NotNull().WithMessage("O campo Email deve ser preenchido.");
        }
    }
}