﻿using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;
using MedicalRecord_API.Repository.Implements;
using Microsoft.EntityFrameworkCore;
using MedicalRecord_API.Utils.AutoMapper;
using MedicalRecord_API.Utils.Recursos.Implements;
using MedicalRecord_API.Utils.Recursos.Interfaces;

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
            services.AddScoped<IParentescoRepository, ParentescoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepositoy>();
            services.AddScoped<ICieRepository, CieRepository>();
            services.AddScoped<IPresentacionRepository, PresentacionRepository>();
            services.AddScoped<IDiabetesRepository, DiabetesRepository>();


            services.AddScoped<ICiaSeguroRepository, CiaSeguroRepository>();
            services.AddScoped<IDirectorioRepository, DirectorioRepository>();
            services.AddScoped<IProcedimientoRepository, ProcedimientoRepository>();
            services.AddScoped<IOcupacionRepository, OcupacionRepository>();
            services.AddScoped<IAlergiaRepository, AlergiaRepository>();
            services.AddScoped<IPacienteRepository, PacienteRepository>();
            services.AddScoped<IMedicamentoRepository, MedicamentoRepository>();
        }
    }
}
