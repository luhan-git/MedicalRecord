using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;
using MedicalRecord_API.Repository.Implements;
using Microsoft.EntityFrameworkCore;
using MedicalRecord_API.Utils.AutoMapper;

namespace MedicalRecord_API.Dependencies
{
    public static class Injections
    {
        public static void Injection(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<DbhistoriasContext>(option => option.UseMySql(configuration.GetConnectionString("Context"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql")));
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}
