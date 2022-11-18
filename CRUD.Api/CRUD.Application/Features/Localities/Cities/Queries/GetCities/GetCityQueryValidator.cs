using FluentValidation;

namespace CRUD.Application.Features.Localities.Cities.Queries.GetCities
{
    /// <summary>
    /// 
    /// </summary>
    public class GetCityQueryValidator : AbstractValidator<GetCityQuery>
    {
        /// <summary>
        /// 
        /// </summary>
        public GetCityQueryValidator()
        {
            When(c => !string.IsNullOrWhiteSpace(c.UF), () =>
            {
                RuleFor(u => u.UF)
                    .MaximumLength(2);
            });

            When(c => !string.IsNullOrWhiteSpace(c.Name), () =>
            {
                RuleFor(u => u.Name)
                    .MaximumLength(60)
                    .MinimumLength(3);
            });
        }
    }
}
