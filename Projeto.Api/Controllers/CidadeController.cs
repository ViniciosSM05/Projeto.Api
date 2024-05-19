using Microsoft.AspNetCore.Mvc;
using Projeto.Api.DataAccess;
using Projeto.Api.Model;

namespace Projeto.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CidadeController(IConfiguration config) : ControllerBase
    {
        [HttpGet(Name = "GetCidades")]
        public IEnumerable<Cidade> Get() => new CidadeDA(config).GetAll();

        [HttpPost(Name = "AddCidade")]
        public Cidade Add(Cidade cidade) => new CidadeDA(config).Add(cidade);

        [HttpPut(Name = "UpdateCidade")]
        public Cidade Update(Cidade cidade) => new CidadeDA(config).Update(cidade);

        [HttpDelete(Name = "DeleteCidade")]
        public int Delete(Guid id) => new CidadeDA(config).Delete(id);
    }
}
