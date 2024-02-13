using Microsoft.AspNetCore.Mvc;
using API_Roteiriza.Data;
using API_Roteiriza.Models;
using Microsoft.EntityFrameworkCore;


namespace API_Roteiriza.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult<UserModel>>Create (UserModel model)
        {
            await _context.Usuarios.AddAsync(model);
            await _context.SaveChangesAsync();

            return Ok(model);
        }

        [HttpGet("Usuarios")]

        public async Task<List<UserModel>> BuscarUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<UserModel> BuscarUsuarioPorId(int id)
        {
            try
            {
                return await _context.Usuarios.FirstOrDefaultAsync(x => x.UserId == id);
            }
            catch
            {
                throw new Exception("Email não cadastrado");
            }
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<ActionResult<UserModel>> AtualizarUsuario(UserModel model, int id)
        {
            UserModel user = await BuscarUsuarioPorId(id);

            if (user == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            user.Name = model.Name;
            user.Email = model.Email;
            user.Password = model.Password;

            _context.Usuarios.Update(user);
            await _context.SaveChangesAsync(); 

            return Ok(model);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<bool>> ApagarUser(int id)
        {
            UserModel user = await BuscarUsuarioPorId(id);

            if (user == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            _context.Usuarios.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(true);
        }
    }
}
