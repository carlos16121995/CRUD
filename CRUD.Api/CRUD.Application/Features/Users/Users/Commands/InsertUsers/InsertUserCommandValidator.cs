using FluentValidation;

namespace CRUD.Application.Features.Users.Users.Commands.InsertUsers
{
    /// <summary>
    /// 
    /// </summary>
    public class InsertUserCommandValidator : AbstractValidator<InsertUserCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public InsertUserCommandValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty()
                .MaximumLength(64);

            RuleFor(u => u.Gender)
                .IsInEnum();

            RuleFor(u => u.BirthDate)
                .Must(birthDate => birthDate.Date < DateTime.UtcNow.Date)
                .WithMessage(e => $"Data de nascimento inválida. Valor informado {e.BirthDate}");
        }
    }
}
