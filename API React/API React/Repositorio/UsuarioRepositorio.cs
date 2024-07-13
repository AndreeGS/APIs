using API_React.Data;
using API_React.Models;
using API_React.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_React.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly DataContext _context;

        public UsuarioRepositorio(DataContext context)
        {
            _context = context;
        }

        public async Task<UsuarioModel> Create(UsuarioModel usuario)
        {
            await _context.Usuarios.AddAsync(usuario);

            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<List<UsuarioModel>> Read()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Update(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioNoBanco = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
                
            if(usuarioNoBanco == null)
            {
                throw new Exception("Usuario não encotrado no Banco!");
            }

            usuarioNoBanco.Name = usuario.Name;
            usuarioNoBanco.Email = usuario.Email;
            usuarioNoBanco.Password = usuario.Password;

            _context.Usuarios.Update(usuarioNoBanco);

            await _context.SaveChangesAsync();

            return usuarioNoBanco;
        }

        public async Task<bool> Delete(int id)
        {
            UsuarioModel usuarioNoBanco = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);

            _context.Usuarios.Remove(usuarioNoBanco);

            await _context.SaveChangesAsync();
            
            return true;
        }
    }
}
