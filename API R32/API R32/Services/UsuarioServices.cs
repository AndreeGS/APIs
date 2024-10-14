using API_R32.Models;
using API_R32.Services.Interfaces;

namespace API_R32.Services
{
    public class UsuarioServices : IUsuarioService
    {
        public Task<UsuarioModel> createUser(UsuarioModel usuario)
        {

            return usuario;
        }
    }
}
