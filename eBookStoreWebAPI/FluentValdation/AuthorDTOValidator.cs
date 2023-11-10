using BusinessObject.DTO;
using FluentValidation;

namespace eBookStoreWebAPI.FluentValdation
{
    public class AuthorDTOValidator : AbstractValidator<AuthorDTO>
    {
        public AuthorDTOValidator() {
            RuleFor(p => p.LastName)
                     .Cascade(CascadeMode.StopOnFirstFailure)
                     .NotEmpty().WithMessage("{PropertyName} should be not empty.")
                     .Length(2, 10);
            RuleFor(p => p.FirstName)
                     .Cascade(CascadeMode.StopOnFirstFailure)
                     .NotEmpty().WithMessage("{PropertyName} should be not empty.")
                     .Length(2, 10);
            RuleFor(p => p.EmailAddress).EmailAddress().WithMessage("Sai dinh dang");

            




        }
    }
}
