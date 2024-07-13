using API_V2.Data;
using API_V2.Dto;
using API_V2.Models;
using API_V2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_V2.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly DataContext _context;

        public UsuarioRepositorio(DataContext context)
        {
            _context = context;
        }

        public async Task<UsuarioModel> Cadastrar(UsuarioModel usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModel> Login(LoginDto login)
        {
            UsuarioModel dado = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == login.Email);

            if (dado == null)
            {
                throw new Exception("Email não cadastrado!");
            }

            if (dado.Password == login.Password)
            {
                return dado;
            }

            else
            {
                throw new Exception("Usuário ou senha incorretos!");
            }

        }
    }
}
