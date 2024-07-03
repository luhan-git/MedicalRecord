using MedicalRecord_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedicalRecord_API.Services.Interfaces
{
    public interface IPacienteService
    {
        Task<Paciente> GetById(int id);
        Task<IEnumerable<Paciente>> List();
        Task<Paciente>Create(Paciente paciente);
    }
}
