using API_React.Models;
using API_React.Repositorio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API_React.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _repositorio;

        public UsuarioController(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult<UsuarioModel>> Create([FromBody] UsuarioModel usuario)
        {
            UsuarioModel usuarioCadastrado = await _repositorio.Create(usuario);

            return Ok(usuarioCadastrado);
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> Read()
        {
            List<UsuarioModel> usuario = await _repositorio.Read();

            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Update(UsuarioModel usuario, int id)
        {
            usuario.Id = id;

            UsuarioModel usuarioDoBanco = await _repositorio.Update(usuario, id);

            return Ok(usuarioDoBanco);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool retorno = await _repositorio.Delete(id);

            return Ok(retorno);
        }

    }
}
