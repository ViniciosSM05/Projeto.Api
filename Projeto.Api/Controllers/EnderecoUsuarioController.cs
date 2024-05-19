using Microsoft.AspNetCore.Mvc;
using Projeto.Api.DataAccess;
using Projeto.Api.Model;

namespace Projeto.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoUsuarioController(IConfiguration config) : ControllerBase
    {
        [HttpGet(Name = "GetEnderecoUsuarios")]
        public IEnumerable<EnderecoUsuario> Get() => new EnderecoUsuarioDA(config).GetAll();

        [HttpPost(Name = "AddEnderecoUsuario")]
        public EnderecoUsuario Add(EnderecoUsuario endereco) => new EnderecoUsuarioDA(config).Add(endereco);

        [HttpPut(Name = "UpdateEnderecoUsuario")]
        public EnderecoUsuario Update(EnderecoUsuario uf) => new EnderecoUsuarioDA(config).Update(uf);

        [HttpDelete(Name = "DeleteEnderecoUsuario")]
        public int Delete(Guid id) => new EnderecoUsuarioDA(config).Delete(id);
    }
}
