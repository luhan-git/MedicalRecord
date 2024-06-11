using FluentValidation;
using MedicalRecord_API.Models.Dtos.Cie;

namespace MedicalRecord_API.Validators.Cie
{
    public class CieCreateDtoValidator : AbstractValidator<CieCreateDto>
    {
        public CieCreateDtoValidator()
        {
            RuleFor(c => c.Codigo).NotEmpty()
                                  .Length(5);
            RuleFor(c => c.Enfermedad).NotEmpty()
                                     .Length(5, 50);
        }
    }
}
