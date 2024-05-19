using Microsoft.AspNetCore.Mvc;
using Projeto.Api.DataAccess;
using Projeto.Api.Model;

namespace Projeto.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoacaoController(IConfiguration config) : ControllerBase
    {
        [HttpGet(Name = "GetDoacoes")]
        public IEnumerable<Doacao> Get() => new DoacaoDA(config).GetAll();

        [HttpPost(Name = "AddDoacao")]
        public Doacao Add(Doacao doacao) => new DoacaoDA(config).Add(doacao);

        [HttpPut(Name = "UpdateDoacao")]
        public Doacao Update(Doacao doacao) => new DoacaoDA(config).Update(doacao);

        [HttpDelete(Name = "DeleteDoacao")]
        public int Delete(Guid id) => new DoacaoDA(config).Delete(id);
    }
}
