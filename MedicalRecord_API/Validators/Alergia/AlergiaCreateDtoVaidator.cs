using FluentValidation;
using MedicalRecord_API.Models.Dtos.Alergia;

namespace MedicalRecord_API.Validators.Alergia
{
    public class AlergiaCreateDtoVaidator : AbstractValidator<AlergiaCreateDto>
    {
        public AlergiaCreateDtoVaidator()
        {
            RuleFor(x => x.Nombre).NotNull()
                                  .NotEmpty()
                                  .Length(5, 20);
        }
    }
}
