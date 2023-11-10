using BusinessObject.DTO;
using FluentValidation;

namespace eBookStoreWebAPI.FluentValdation
{
    public class BookDTOValidator : AbstractValidator<BookDTO>
    {
        public BookDTOValidator()
        {
            RuleFor(p => p.Title)
                     .Cascade(CascadeMode.StopOnFirstFailure)
                     .NotEmpty().WithMessage(" should be not empty.")
                     .Length(2, 25);

            RuleFor(p => p.Price)
                .NotEmpty()
                .WithMessage("Price is required.")
                .GreaterThan(0)
                .WithMessage("Price must be greater than 0.");
           
        }
    }
}
