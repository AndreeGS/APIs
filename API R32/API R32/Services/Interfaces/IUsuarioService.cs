using API_R32.Models;

namespace API_R32.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioModel> createUser(UsuarioModel usuario);

    }
}
