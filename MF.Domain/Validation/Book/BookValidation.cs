using FluentValidation;

namespace MF.Domain.Validation.Book
{
    public class BookValidation:AbstractValidator<Entities.Book.Book>
    {
        public BookValidation()
        {
            RuleFor(v => v.BookName).NotEmpty().NotNull().WithMessage("Nome do Livro inválido, tente novamente!");
            RuleFor(v => v.Author).NotEmpty().NotNull().WithMessage("Autor inválido, tente novamente!");
            RuleFor(v => v.PublishingCompany).NotEmpty().NotNull().WithMessage("Editora inválida, tente novamente!");
            RuleFor(v => v.PostedDate).NotEmpty().NotNull().WithMessage("Data de Publicação inválida, tente novamente!");
            RuleFor(v => v.Edition).NotEmpty().NotNull().WithMessage("Edição inválida, tente novamente!");
            RuleFor(v => v.Status).NotEmpty().NotNull().WithMessage("Status do livro é inválido, tente novamente!");
        }
    }
}