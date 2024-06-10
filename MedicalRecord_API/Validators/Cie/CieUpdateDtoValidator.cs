using FluentValidation;
using MedicalRecord_API.Models.Dtos.Cie;

namespace MedicalRecord_API.Validators.Cie
{
    public class CieUpdateDtoValidator:AbstractValidator<CieUpdateDto>
    {
        public CieUpdateDtoValidator()
        {
            RuleFor(c=> c.Id).NotEmpty()
                             .GreaterThan(0);
            RuleFor(c=> c.Codigo).NotEmpty()
                                .Length(5);
            RuleFor(c=> c.Enfermedad).NotEmpty()
                                   .Length(5,50);
        }
    }
}
