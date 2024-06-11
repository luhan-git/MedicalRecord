using FluentValidation;
using MedicalRecord_API.Models.Dtos.CiaSeguro;

namespace MedicalRecord_API.Validators.CiaSeguro
{
    public class CiaSeguroCreateDtoValidator : AbstractValidator<CiaSeguroCreateDto>
    {
        public CiaSeguroCreateDtoValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty()
                                  .Length(5, 50);
            RuleFor(x => x.Abreviatura).NotNull()
                                       .NotEmpty()
                                       .Length(2, 5);
        }
    }
}
