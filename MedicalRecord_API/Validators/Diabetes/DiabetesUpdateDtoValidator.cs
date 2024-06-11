using FluentValidation;
using MedicalRecord_API.Models.Dtos.Diabetes;

namespace MedicalRecord_API.Validators.Diabetes
{
    public class DiabetesUpdateDtoValidator : AbstractValidator<DiabetesUpdateDto>
    {
        public DiabetesUpdateDtoValidator()
        {
            RuleFor(d => d.Id).NotEmpty()
                             .GreaterThan(0);
            RuleFor(d => d.Tipo).NotEmpty()
                              .Length(5, 50);
            RuleFor(d => d.Detalle).NotEmpty()
                                .Length(5, 50);
        }
    }
}
