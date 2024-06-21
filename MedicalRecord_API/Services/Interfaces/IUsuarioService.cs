//using MedicalRecord_API.Models;
//using System.Linq.Expressions;

//namespace MedicalRecord_API.Services.Interfaces
//{
//    public interface IUsuarioService
//    {
//        Task<Usuario> GetAsync(Expression<Func<Usuario, bool>> filters, bool tracked = true);
//        Task<IEnumerable<Usuario>> QueryAsync(Expression<Func<Usuario, bool>>? filter = null,
//                                            params Expression<Func<Usuario, object>>[] Includes);
//        Task<Usuario> Create(Usuario usuario);
//        Task Update(Usuario usuario);
//        Task Delete(Usuario usuario);
//        Task<bool> IsUserUnique(string correo);

//    }
//}