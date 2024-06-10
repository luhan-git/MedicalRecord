using FluentValidation;
using MedicalRecord_API.Models.Dtos.CiaSeguro;

namespace MedicalRecord_API.Validators.CiaSeguro
{
    public class CiaSeguroUpdateDtoValidator:AbstractValidator<CiaSeguroUpdateDto>
    {
        public CiaSeguroUpdateDtoValidator()
        {
            RuleFor(x=>x.Id).NotNull().NotEmpty().GreaterThan(0);
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
