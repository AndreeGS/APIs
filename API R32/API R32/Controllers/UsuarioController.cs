using API_R32.Models;
using API_R32.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_R32.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> createUser(UsuarioModel usuario)
        {
            await _usuarioService.create(usuario);

            return Ok(usuario);
        }
    }
}
