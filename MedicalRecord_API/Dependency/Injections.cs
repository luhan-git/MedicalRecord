using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Implements;
using MedicalRecord_API.Repository.Interfaces;
using MedicalRecord_API.Services.Implements;
using MedicalRecord_API.Services.Interfaces;
using MedicalRecord_API.Utils.AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace MedicalRecord_API.Dependency
{
    public static class Injections
    {
        public static void Injection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbhistoriasContext>(option => option.UseMySql(configuration.GetConnectionString("Context"),
                                                      Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddScoped<IUtilsService, UtilsService>();
            services.AddScoped<IExamenLaboratorioRepository, ExamenLaboratorioRepository>();
            services.AddScoped<IParentescoRepository, ParentescoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepositoy>();
            services.AddScoped<ICieRepository, CieRepository>();
            services.AddScoped<IPresentacionRepository, PresentacionRepository>();
            services.AddScoped<IDiabetesRepository, DiabetesRepository>();
            services.AddScoped<ILaboratorioRepository, LaboratorioRepository>();
            services.AddScoped<ICiaSeguroRepository, CiaSeguroRepository>();
            services.AddScoped<IDirectorioRepository, DirectorioRepository>();
            services.AddScoped<IProcedimientoRepository, ProcedimientoRepository>();
            services.AddScoped<IOcupacionRepository, OcupacionRepository>();
            services.AddScoped<IAlergiaRepository, AlergiaRepository>();
            services.AddScoped<IPacienteRepository, PacienteRepository>();
            services.AddScoped<IMedicamentoRepository, MedicamentoRepository>();
            services.AddScoped<IConsultaRepository, ConsultaRepository>();

            services.AddScoped<IPresentacionService, PresentacionService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAlergiaService, AlergiaService>();
            services.AddScoped<ICiaSeguroService, CiaSeguroService>();
            services.AddScoped<ICieService, CieService>();
            services.AddScoped<IDiabetesService, DiabetesService>();
        }
    }
}
