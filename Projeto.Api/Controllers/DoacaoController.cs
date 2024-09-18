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
    public class DoacaoController(IConfiguration config) : BaseController
    {
        [HttpGet(Name = "GetDoacoes")]
        public ActionResult<ResultDataDTO<IEnumerable<Doacao>>> Get()
            => Execute(() => new DoacaoDA(config).GetAll());

        [HttpPost(Name = "AddDoacao")]
        public ActionResult<ResultDataDTO<Doacao>> Add(Doacao doacao)
            => Execute(() => new DoacaoDA(config).Add(doacao));

        [HttpPut(Name = "UpdateDoacao")]
        public ActionResult<ResultDataDTO<Doacao>> Update(Doacao doacao)
            => Execute(() => new DoacaoDA(config).Update(doacao));

        [HttpDelete(Name = "DeleteDoacao")]
        public ActionResult<ResultDataDTO<int>> Delete(Guid id)
            => Execute(() => new DoacaoDA(config).Delete(id));
    }
}
