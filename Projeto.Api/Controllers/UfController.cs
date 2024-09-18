using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto.Api.Controllers.Base;
using Projeto.Api.DataAccess;
using Projeto.Api.DTO;
using Projeto.Api.Model;

namespace Projeto.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class UfController(IConfiguration config) : BaseController
    {
        [HttpGet(Name = "GetUfs")]
        public ActionResult<ResultDataDTO<IEnumerable<Uf>>> Get()
            => Execute(() => new UfDA(config).GetAll());

        [HttpPost(Name = "AddUf")]
        public ActionResult<ResultDataDTO<Uf>> Add(Uf uf)
            => Execute(() => new UfDA(config).Add(uf));

        [HttpPut(Name = "UpdateUf")]
        public ActionResult<ResultDataDTO<Uf>> Update(Uf uf)
            => Execute(() => new UfDA(config).Update(uf));

        [HttpDelete(Name = "DeleteUf")]
        public ActionResult<ResultDataDTO<int>> Delete(string sigla)
            => Execute(() => new UfDA(config).Delete(sigla));
    }
}
