using FluentValidation;
using MedicalRecord_API.Models.Dtos.Diabetes;

namespace MedicalRecord_API.Validators.Diabetes
{
    public class DiabetesCreateDtoValidator : AbstractValidator<DiabetesCreateDto>
    {
        public DiabetesCreateDtoValidator()
        {
            RuleFor(d => d.Tipo).NotEmpty().Length(5, 50);
            RuleFor(d => d.Detalle).NotEmpty().Length(5, 50);
        }
    }
}
