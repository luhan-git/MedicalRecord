using AutoMapper;
using MedicalRecord_API.Models;
using MedicalRecord_API.Models.Dtos.Alergia;
using MedicalRecord_API.Models.Dtos.CiaSeguro;
using MedicalRecord_API.Models.Dtos.Cie;
using MedicalRecord_API.Models.Dtos.Diabetes;
using MedicalRecord_API.Models.Dtos.Directorio;
using MedicalRecord_API.Models.Dtos.ExamenLaboratorio;
using MedicalRecord_API.Models.Dtos.Ocupacion;
using MedicalRecord_API.Models.Dtos.Parentesco;
using MedicalRecord_API.Models.Dtos.Presentacion;
using MedicalRecord_API.Models.Dtos.Procedimiento;
using MedicalRecord_API.Models.Dtos.Usuario;
using MedicalRecord_API.Models.Dtos.Paciente;
using MedicalRecord_API.Models.Dtos.Ubicacion;
using MedicalRecord_API.Models.Dtos.DetalleAlergia;
using MedicalRecord_API.Models.Dtos.Medicamento;
using MedicalRecord_API.Models.Dtos.Consulta;
using MedicalRecord_API.Models.Dtos.ExamenLab;
using MedicalRecord_API.Models.Dtos.Laboratorio;

namespace MedicalRecord_API.Utils.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            #region Usuario
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Usuario, UsuarioRegistroDto>().ReverseMap();
            CreateMap<Usuario, UsuarioUpdateDto>().ReverseMap();
            CreateMap<Usuario,PerfilDto>().ReverseMap();
            #endregion Usuario

            #region Cie
            CreateMap<Cie, CieDto>().ReverseMap();
            CreateMap<Cie,CieCreateDto>().ReverseMap();
            CreateMap<Cie,CieUpdateDto>().ReverseMap();
            #endregion Cie

            #region Presentacion
            CreateMap<Presentacion, PresentacionDto>().ReverseMap();
            CreateMap<Presentacion, PresentacionCreateDto>().ReverseMap();
            CreateMap<Presentacion, PresentacionUpdateDto>().ReverseMap();
            #endregion Presentacion

            #region ExamenLaboratorio
            CreateMap<Examenlaboratorio, ExamenLabDto>().ReverseMap();
            CreateMap<Examenlaboratorio, ExamenLaboratorioCreateDto>().ReverseMap();
            CreateMap<Examenlaboratorio, ExamenLaboratorioUpdateDto>().ReverseMap();
            #endregion ExamenLaboratorio 
            #region Laboratorio
            CreateMap<Laboratorio,LaboratorioDto>().ReverseMap();
            #endregion Laboratorio
            #region Diabetes
            CreateMap<Diabete, DiabetesDto>().ReverseMap();
            CreateMap<Diabete, DiabetesCreateDto>().ReverseMap();
            CreateMap<Diabete, DiabetesUpdateDto>().ReverseMap();
            #endregion Diabetes
            #region Parentesco
            CreateMap<Parentesco, ParentescoDto>().ReverseMap();
            CreateMap<Parentesco, ParentescoCreateDto>().ReverseMap();
            CreateMap<Parentesco, ParentescoUpdateDto>().ReverseMap();
            #endregion Parentesco 
            #region Ubicacion
            CreateMap<Departamento, DepartamentoDto>().ReverseMap();
            CreateMap<Provincium, ProvinciaDto>().ReverseMap();
            CreateMap<Distrito, DistritoDto>().ReverseMap();
            #endregion Ubicacion

            #region CiaSeguros
            CreateMap<Ciaseguro, CiaSeguroCreateDto>().ReverseMap();
            CreateMap<Ciaseguro, CiaSeguroUpdateDto>().ReverseMap();
            CreateMap<Ciaseguro, CiaSeguroDto>().ReverseMap();
            #endregion CiaSeguros

            #region Directorio
            CreateMap<Directorio, DirectorioDto>().ReverseMap();
            CreateMap<Directorio, DirectorioCreateDto>().ReverseMap();
            CreateMap<Directorio, DirectorioUpdateDto>().ReverseMap();
            #endregion Directorio

            #region Procedimiento
            CreateMap<Procedimiento, ProcedimientoDto>().ReverseMap();
            CreateMap<Procedimiento, ProcedimientoCreateDto>().ReverseMap();
            CreateMap<Procedimiento, ProcedimientoUpdateDto>().ReverseMap();
            #endregion Procedimiento

            #region Ocupacion
            CreateMap<Ocupacion, OcupacionDto>().ReverseMap();
            CreateMap<Ocupacion, OcupacionCreateDto>().ReverseMap();
            CreateMap<Ocupacion, OcupacionUpdateDto>().ReverseMap();
            #endregion Ocupacion

            #region Alergia
            CreateMap<Alergium, AlergiaDto>().ReverseMap();
            CreateMap<Alergium, AlergiaCreateDto>().ReverseMap();
            CreateMap<Alergium, AlergiaUpdateDto>().ReverseMap();
            CreateMap<Detallealergium, DetalleAlergiaCreateDto>().ReverseMap();

            #endregion Alergia

            #region Paciente
            CreateMap<Paciente, PacienteDetalleDto>().ReverseMap();
            CreateMap<Paciente, PacienteCreateDto>().ReverseMap();


            CreateMap<Paciente, PacienteUpdateDto>().ReverseMap();
            CreateMap<Paciente,PacienteDto>().ReverseMap();
            #endregion Paciente

            #region Medicamento
            CreateMap<Medicamento, MedicamentoCreateDto>().ReverseMap();
            CreateMap<Medicamento, MedicamentoUpdateDto>().ReverseMap();

            CreateMap<Medicamento, MedicamentoDto>()
                .ForMember(dest => dest.Presentacion, opt => opt.MapFrom(origen => origen.IdPresentacionNavigation.Nombre));
                
            #endregion Medicamento

            #region Consulta
            CreateMap<Consultum, ConsultaDto>()
                .ForMember(dest => dest.IdCieNavigation, opt => opt.MapFrom(src => src.IdCieNavigation))
                .ForMember(dest => dest.IdPacienteNavigation, opt => opt.MapFrom(src => src.IdPacienteNavigation))
                .ForMember(dest => dest.IdUsuarioNavigation, opt => opt.MapFrom(src => src.IdUsuarioNavigation))
                .ReverseMap();
            CreateMap<Consultum, ConsultaCreateDto>().ReverseMap();
            CreateMap<Consultum, ConsultaUpdateDto>().ReverseMap();
            #endregion Consulta

        }
    }
}
