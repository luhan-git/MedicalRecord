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

namespace MedicalRecord_API.Utils.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            #region Usuario
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Usuario, UsuarioCreateDto>().ReverseMap();
            CreateMap<Usuario, UsuarioUpdateDto>().ReverseMap();
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
            CreateMap<Examenlaboratorio, ExamenLaboratorioDto>().ReverseMap();
            CreateMap<Examenlaboratorio, ExamenLaboratorioCreateDto>().ReverseMap();
            CreateMap<Examenlaboratorio, ExamenLaboratorioUpdateDto>().ReverseMap();
            #endregion ExamenLaboratorio 
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
            #endregion Alergia

        }
    }
}
