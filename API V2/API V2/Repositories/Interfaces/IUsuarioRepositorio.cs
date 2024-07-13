using API_V2.Dto;
using API_V2.Models;

namespace API_V2.Repositories.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<UsuarioModel> Cadastrar(UsuarioModel usuario);
        Task<UsuarioModel> Login(LoginDto login);

    }
}
