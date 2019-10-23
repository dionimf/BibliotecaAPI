using FluentValidation;
using MF.Domain.Entities;
using MF.Domain.Entities.User;

namespace MF.Domain.Validation
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(v => v.FirstName)
                .NotEmpty().NotNull().WithMessage("O campo Primeiro Nome deve ser preenchido");
            RuleFor(v => v.LastName)
                .NotEmpty().NotNull().WithMessage("O campo Sobrenome deve ser preenchido");
            RuleFor(v => v.Login)
                .NotEmpty().NotNull().MinimumLength(3).WithMessage("O campo Login deve ser preenchido");
            RuleFor(v => v.Password)
                .NotEmpty().NotNull().MinimumLength(6).WithMessage("O campo Senha deve ser preenchido");
            RuleFor(v => v.Contact)
                .Must(ContactValidate);
            RuleFor(v => v.Address)
                .Must(AddressValidate);
        }

        public bool ContactValidate(Contact contact)
        {
            return new ContactValidation().Validate(contact).IsValid;
        }

        public bool AddressValidate(Address address)
        {
            return new AddressValidation().Validate(address).IsValid;
        }
    }
}