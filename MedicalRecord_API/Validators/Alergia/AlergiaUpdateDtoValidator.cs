using FluentValidation;
using MedicalRecord_API.Models.Dtos.Alergia;

namespace MedicalRecord_API.Validators.Alergia
{
    public class AlergiaUpdateDtoValidator:AbstractValidator<AlergiaUpdateDto>
    {
        public AlergiaUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotNull()
                               .NotEmpty()
                               .GreaterThan(0);
            RuleFor(x => x.Nombre).NotNull()
                                  .NotEmpty()
                                  .MaximumLength(20)
                                  .MinimumLength(5);
        }
    }
}
