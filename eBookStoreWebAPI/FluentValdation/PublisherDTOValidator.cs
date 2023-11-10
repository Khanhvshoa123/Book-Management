using BusinessObject.DTO;
using FluentValidation;

namespace eBookStoreWebAPI.FluentValdation
{
    public class PublisherDTOValidator : AbstractValidator<PublisherDTO>
    {
        public PublisherDTOValidator()
        {
            RuleFor(p => p.PublisherName)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty().WithMessage(" should be not empty.")
                    .Length(2, 25);
            RuleFor(p => p.City).Must(a => a?.ToLower().Contains("street") == true).WithMessage("City must content street");

        }
    }
}
