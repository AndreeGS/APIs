using API_Roteiriza.Data;
using API_Roteiriza.Models;
using API_Roteiriza.Repositories.IRepositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace API_Roteiriza.Repositories
{
    public class UserRepositorie : IUserRepositorie
    {
        private readonly DataContext _context;

        public UserRepositorie(DataContext dataContext)
        {
            _context = dataContext;
        }

       public async Task<UserModel> Cadastrar(UserModel model)
        {
            await _context.Usuarios.AddAsync(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<List<UserModel>> VisualizarUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<UserModel> ProcuarUsuarioPorId(int id)
        {
            UserModel user = await _context.Usuarios.FirstOrDefaultAsync(x => x.UserId == id);

            return user;
        }

        public async Task<UserModel> AtualizarUsuario(UserModel user, int id)
        {
            UserModel usuarioPorId = await ProcuarUsuarioPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception("Não encontrado!");
            }

            usuarioPorId.Name = user.Name;
            usuarioPorId.Email = user.Email;
            usuarioPorId.Password = user.Password;

             _context.Usuarios.Update(usuarioPorId);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> DeletarUsuario(int id)
        {
            UserModel usuarioPorId = await ProcuarUsuarioPorId(id);

            if(usuarioPorId == null)
            {
                throw new Exception("Usuairo não encotrado");
            }

            _context.Usuarios.Remove(usuarioPorId);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<CardTravelModel> BuscarViagem(int idUser, int idTravel)
        {
            UserModel user = await ProcuarUsuarioPorId(idUser);

            if (user == null)
            {
                throw new Exception("Usuário não encontrado!");
            }

            if(user.CardTravel == null)
            {
                throw new Exception("O Usuário não possui viagens!");
            }

            CardTravelModel travel = user.CardTravel;

            return travel;
        }



        /*

        public async Task<List<CardTravelModel>> BuscarViagensDoUsuario(int idUser)
        {
            UserModel user = await ProcuarUsuarioPorId(idUser);
            
            if(user == null)
            {
                throw new Exception("Usuairo não encontrado");
            }

            if(user.CardTravel == null)
            {
                throw new Exception("O Usuário não possui viagens!");
            }

           return Ok();
        }
        */
    }
}
