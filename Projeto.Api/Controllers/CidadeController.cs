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
    public class CidadeController(IConfiguration config) : BaseController
    {
        [HttpGet(Name = "GetCidades")]
        public ActionResult<ResultDataDTO<IEnumerable<Cidade>>> Get()
            => Execute(() => new CidadeDA(config).GetAll());

        [HttpPost(Name = "AddCidade")]
        public ActionResult<ResultDataDTO<Cidade>> Add(Cidade cidade)
           => Execute(() => new CidadeDA(config).Add(cidade));

        [HttpPut(Name = "UpdateCidade")]
        public ActionResult<ResultDataDTO<Cidade>> Update(Cidade cidade)
            => Execute(() => new CidadeDA(config).Update(cidade));

        [HttpDelete(Name = "DeleteCidade")]
        public ActionResult<ResultDataDTO<int>> Delete(Guid id)
            => Execute(() => new CidadeDA(config).Delete(id));
    }
}
