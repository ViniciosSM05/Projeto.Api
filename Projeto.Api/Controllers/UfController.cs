using Microsoft.AspNetCore.Mvc;
using Projeto.Api.DataAccess;
using Projeto.Api.Model;

namespace Projeto.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UfController(IConfiguration config) : ControllerBase
    {
        [HttpGet(Name = "GetUfs")]
        public IEnumerable<Uf> Get() => new UfDA(config).GetAll();

        [HttpPost(Name = "AddUf")]
        public Uf Add(Uf uf) => new UfDA(config).Add(uf);

        [HttpPut(Name = "UpdateUf")]
        public Uf Update(Uf uf) => new UfDA(config).Update(uf);

        [HttpDelete(Name = "DeleteUf")]
        public int Delete(string sigla) => new UfDA(config).Delete(sigla);
    }
}
