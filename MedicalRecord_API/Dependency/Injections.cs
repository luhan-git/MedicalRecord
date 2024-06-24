using MedicalRecord_API.Models;
using MedicalRecord_API.Repository;
using MedicalRecord_API.Repository.Implements;
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
            services.AddDbContext<MedicalrecordContext>(option => option.UseMySql(configuration.GetConnectionString("Context"),
                                                      Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IPacienteService, PacienteService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddScoped<IUtilsService, UtilsService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUbicacionService, UbicacionService>();
        }
    }
}
