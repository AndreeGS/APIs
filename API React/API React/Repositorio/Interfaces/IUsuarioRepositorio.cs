using API_React.Models;

namespace API_React.Repositorio.Interfaces
{
    public interface IUsuarioRepositorio
    {
         Task<UsuarioModel> Create(UsuarioModel usuario);

         Task<List<UsuarioModel>> Read();

         Task<UsuarioModel> Update(UsuarioModel usuario, int id);

         Task<bool> Delete(int id);

    }
}
