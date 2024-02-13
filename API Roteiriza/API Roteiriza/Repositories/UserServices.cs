using API_Roteiriza.Data;
using API_Roteiriza.Models;

namespace API_Roteiriza.Repositories
{
    public class UserServices
    {
        private readonly DataContext _context;

        public UserServices(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<UserModel> CadastrarUsuario(UserModel usuario)
        {
            await _context.AddAsync(usuario);
            return usuario;
        }
    }
}
