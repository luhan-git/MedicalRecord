using FluentValidation;
using MedicalRecord_API.Models.Dtos.CiaSeguro;

namespace MedicalRecord_API.Validators.CiaSeguro
{
    public class CiaSeguroCreateDtoValidator:AbstractValidator<CiaSeguroCreateDto>
    {
        public CiaSeguroCreateDtoValidator()
        {
            RuleFor(x => x.Nombre).NotNull()
                                  .NotEmpty()
                                  .MaximumLength(50).
                                  MinimumLength(5);
            RuleFor(x => x.Abreviatura).NotNull()
                                       .NotEmpty()
                                       .MaximumLength(5)
                                       .MinimumLength(2);
        }
    }
}
