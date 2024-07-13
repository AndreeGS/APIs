using API_V2.Dto;
using API_V2.Models;
using API_V2.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_V2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult<UsuarioModel>> Cadastrar ([FromBody] UsuarioModel usuario)
        {
            UsuarioModel usuarioCadastrado = await _usuarioRepositorio.Cadastrar(usuario);

            return Ok(usuario);
        }

        [HttpPost("Login")]

        public async Task<ActionResult<UsuarioModel>> Login (LoginDto login)
        {
            UsuarioModel usuario = await _usuarioRepositorio.Login(login);

            return Ok(usuario);
        }
      
    }
}
