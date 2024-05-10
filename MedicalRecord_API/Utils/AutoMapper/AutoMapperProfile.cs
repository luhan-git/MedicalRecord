using AutoMapper;
using MedicalRecord_API.Models;
using MedicalRecord_API.Models.Dtos.Cie;
using MedicalRecord_API.Models.Dtos.Medico;

namespace MedicalRecord_API.Utils.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            #region Medico
            CreateMap<Medico, MedicoDto>().ReverseMap();
            CreateMap<Medico, MedicoCreateDto>().ReverseMap();
            CreateMap<Medico, MedicoUpdateDto>().ReverseMap();
            #endregion Medico
            #region Cie
            CreateMap<Cie, CieDto>().ReverseMap();
            CreateMap<Cie,CieCreateDto>().ReverseMap();
            CreateMap<Cie,CieUpdateDto>().ReverseMap();
            #endregion Cie
            //#region CiaSeguros
            //CreateMap<CiaSeguros, CiaSegurosDto>().ReverseMap();
            //CreateMap<CiaSeguros, CiaSegurosCreateDto>().ReverseMap();
            //CreateMap<CiaSeguros, CiaSegurosUpdateDto>().ReverseMap();
            //#endregion CiaSeguros

            //#region Directorio
            //CreateMap<Directorio, DirectorioDto>().ReverseMap();
            //CreateMap<Directorio, DirectorioCreateDto>().ReverseMap();
            //CreateMap<Directorio, DirectorioUpdateDto>().ReverseMap();
            //#endregion Directorio

            //#region Procedimiento
            //CreateMap<Procedimiento, ProcedimientoDto>().ReverseMap();
            //CreateMap<Procedimiento, ProcedimientoCreateDto>().ReverseMap();
            //CreateMap<Procedimiento, ProcedimientoUpdateDto>().ReverseMap();
            //#endregion Procedimiento

            //#region Ocupacion
            //CreateMap<Ocupacion, OcupacionDto>().ReverseMap();
            //CreateMap<Ocupacion, OcupacionCreateDto>().ReverseMap();
            //CreateMap<Ocupacion, OcupacionUpdateDto>().ReverseMap();
            //#endregion Ocupacion

        }
    }
}
