using Microsoft.AspNetCore.Mvc;
using API_Roteiriza.Data;
using API_Roteiriza.Models;
using Microsoft.EntityFrameworkCore;
using API_Roteiriza.Repositories.IRepositories;


namespace API_Roteiriza.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepositorie _userRepositorie;
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult<UserModel>>Create ([FromBody]UserModel usermodel)
        {
            await _context.Usuarios.AddAsync(usermodel);
            await _context.SaveChangesAsync();

            return Ok(usermodel);
        }

        [HttpGet("Usuarios")]
        public async Task<ActionResult<List<UserModel>>> BuscarUsuarios()
        {
            List<UserModel> usuarios = await _context.Usuarios.ToListAsync();

            return usuarios.ToList();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> BuscarUsuarioPorId(int id)
        {
            UserModel usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.UserId == id);

            return Ok(usuario);
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<ActionResult<UserModel>> AtualizarUsuario(UserModel user, int id)
        {
            UserModel usuarioPorId = await _context.Usuarios.FirstOrDefaultAsync(x => x.UserId == id);

            if (usuarioPorId == null)
            {
                throw new Exception("Não encontrado!");
            }

            usuarioPorId.Name = user.Name;
            usuarioPorId.Email = user.Email;
            usuarioPorId.Password = user.Password;

            _context.Usuarios.Update(usuarioPorId);
            await _context.SaveChangesAsync();

            return Ok(usuarioPorId);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<bool>> ApagarUser(int id)
        {
            UserModel usuarioPorId = await _context.Usuarios.FirstOrDefaultAsync(x => x.UserId == id);

            if (usuarioPorId == null)
            {
                throw new Exception("Usuairo não encotrado");
            }

            _context.Usuarios.Remove(usuarioPorId);
            await _context.SaveChangesAsync();

            return true;
        }

        [HttpGet]
        public async Task<ActionResult<CardTravelModel>> BuscarViagem(int idUser, int idTravel)
        {
            UserModel user = await _context.Usuarios.FirstOrDefaultAsync(c => c.UserId == idUser);

            if (user == null)
            {
                throw new Exception("Usuário não encontrado!");
            }

            if (user.CardTravel == null)
            {
                throw new Exception("O Usuário não possui viagens!");
            }

            CardTravelModel travel = user.CardTravel;

            return travel;
        }
    }
}
