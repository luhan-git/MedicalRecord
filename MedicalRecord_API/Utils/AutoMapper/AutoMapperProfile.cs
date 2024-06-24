using AutoMapper;
using MedicalRecord_API.Models;
using MedicalRecord_API.Models.Dtos.Paciente;
using MedicalRecord_API.Models.Dtos.Ubicacion;
using MedicalRecord_API.Models.Dtos.Usuario;

namespace MedicalRecord_API.Utils.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Usuario
            CreateMap<Usuario, UsuarioListDto>().ReverseMap();
            CreateMap<Usuario, UsuarioCreateDto>().ReverseMap();
            CreateMap<Usuario, UsuarioUpdateDto>().ReverseMap();
            CreateMap<Usuario, PerfilDto>().ReverseMap();
            #endregion Usuario
            #region Paciente
            CreateMap<Paciente, PacienteListDto>().ReverseMap();
            CreateMap<Paciente, PacienteDto>()
                     .ForMember(dest => dest.Departamento,
                      opt => opt.MapFrom(origen => origen.IdDepartamentoNavigation.Nombre))
                     .ForMember(dest => dest.Provincia,
                     opt => opt.MapFrom(origen => origen.IdProvinciaNavigation.Nombre))
                     .ForMember(dest => dest.Distrito,
                     opt => opt.MapFrom(origen => origen.IdDistritoNavigation.Nombre))
                     .ForMember(dest => dest.Seguro,
                     opt => opt.MapFrom(origen => origen.IdSeguroNavigation.Nombre))
                     .ForMember(dest => dest.Ocupacion,
                     opt => opt.MapFrom(origen => origen.IdOcupacionNavigation.Nombre))
                     .ForMember(dest => dest.Contactos,
                     opt => opt.MapFrom(origen => origen.Contactos))
                     .ForMember(dest => dest.Antecedente,
                     opt => opt.MapFrom(origen => origen.Antecedente));

            CreateMap<Contacto, ContactoDto>()
                .ForMember(dest=> dest.Parentesco,
                opt=> opt.MapFrom(origen=> origen.IdParentescoNavigation.Nombre));
            CreateMap<Antecedente, AntecedenteDto>()
                .ForMember(dest => dest.Diabetes,
                opt => opt.MapFrom(d => d.IdDiabeteNavigation.Nombre));
            CreateMap<Detallealergia, DetalleAlergiaDto>()
                      .ForMember(dest=> dest.Alergia,
                      opt=> opt.MapFrom(origen=> origen.IdAlergiaNavigation.Nombre));
            #endregion Paciente
            #region Ubicacion 
            CreateMap<Departamento, DepartamentoDto>();
            CreateMap<Provincia, ProvinciaDto>();
            CreateMap<Distrito, DistritoDto>();
            #endregion
        }
    }
}
