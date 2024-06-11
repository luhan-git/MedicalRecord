using FluentValidation;
using MedicalRecord_API.Models.Dtos.CiaSeguro;

namespace MedicalRecord_API.Validators.CiaSeguro
{
    public class CiaSeguroUpdateDtoValidator : AbstractValidator<CiaSeguroUpdateDto>
    {
        public CiaSeguroUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty()
                            .GreaterThan(0);
            RuleFor(x => x.Nombre).NotNull()
                                  .NotEmpty()
                                  .Length(5, 50);
            RuleFor(x => x.Abreviatura).NotNull()
                                       .NotEmpty()
                                       .Length(5, 50);
        }
    }
}
