using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;
using MedicalRecord_API.Repository.Implements;
using Microsoft.EntityFrameworkCore;
using MedicalRecord_API.Utils.AutoMapper;
using MedicalRecord_API.Utils.encrypt.Implements;
using MedicalRecord_API.Utils.encrypt.Interfaces;

namespace MedicalRecord_API.Dependencies
{
    public static class Injections
    {
        public static void Injection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbhistoriasContext>(option => option.UseMySql(configuration.GetConnectionString("Context"),
                                                      Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql")));

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddScoped<IUtilsService, UtilsService>();
            services.AddScoped<IExamenLaboratorioRepository, ExamenLaboratorioRepository>();

            services.AddScoped<IUsuarioRepository, UsuarioRepositoy>();
            services.AddScoped<ICieRepository, CieRepository>();
            services.AddScoped<IPresentacionRepository, PresentacionRepository>();
            services.AddScoped<ICiaSeguroRepository, CiaSeguroRepository>();
        }
    }
}
