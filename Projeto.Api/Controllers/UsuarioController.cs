using Microsoft.AspNetCore.Mvc;
using Projeto.Api.DataAccess;
using Projeto.Api.Model;

namespace Projeto.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController(IConfiguration config) : ControllerBase
    {
        [HttpGet(Name = "GetUsuarios")]
        public IEnumerable<Usuario> Get() => new UsuarioDA(config).GetAll();

        [HttpPost(Name = "AddUsuario")]
        public Usuario Add(Usuario usuario) => new UsuarioDA(config).Add(usuario);

        [HttpPut(Name = "UpdateUsuario")]
        public Usuario Update(Usuario usuario) => new UsuarioDA(config).Update(usuario);

        [HttpDelete(Name = "DeleteUsuario")]
        public int Delete(Guid id) => new UsuarioDA(config).Delete(id);
    }
}
