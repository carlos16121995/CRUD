using FluentValidation;

namespace CRUD.Application.Features.Users.Users.Queries.GetUsers
{
    /// <summary>
    /// 
    /// </summary>
    public class GetUserQueryValidator : AbstractValidator<GetUserQuery>
    {
        /// <summary>
        /// 
        /// </summary>
        public GetUserQueryValidator()
        {
            When(u => !string.IsNullOrWhiteSpace(u.Name), () =>
            {
                RuleFor(u => u.Name)
                .MaximumLength(64)
                .MinimumLength(3);
            });
        }
    }
}
