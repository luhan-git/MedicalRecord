using AutoMapper;
using MedicalRecord_API.Models;
using MedicalRecord_API.Models.Dtos;

namespace MedicalRecord_API.Utils.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Medico, MedicoDto>().ReverseMap();
            CreateMap<Medico, MedicoCreateDto>().ReverseMap();
            CreateMap<Medico, MedicoUpdateDto>().ReverseMap();

        }
    }
}
