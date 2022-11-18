using FluentValidation;

namespace CRUD.Application.Features.Localities.States.Queries.GetState
{
    /// <summary>
    /// 
    /// </summary>
    public class GetStateQueryValidator : AbstractValidator<GetStateQuery>
    {
        /// <summary>
        /// 
        /// </summary>
        public GetStateQueryValidator()
        {
            When(c => !string.IsNullOrWhiteSpace(c.UF), () =>
            {
                RuleFor(u => u.UF)
                    .MaximumLength(2);
            });

            When(c => !string.IsNullOrWhiteSpace(c.Name), () =>
            {
                RuleFor(u => u.Name)
                    .MaximumLength(32)
                    .MinimumLength(3);
            });
        }
    }
}
