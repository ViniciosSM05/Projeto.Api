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
        /// <summary>
        /// Obtém uma lista de objetos de todos as UFs
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetUfs")]
        public ActionResult<ResultDataDTO<IEnumerable<Uf>>> Get()
            => Execute(() => new UfDA(config).GetAll());

        /// <summary>
        /// Adiciona uma nova UF
        /// </summary>
        /// <param name="uf"></param>
        /// <returns></returns>
        [HttpPost(Name = "AddUf")]
        public ActionResult<ResultDataDTO<Uf>> Add(Uf uf)
            => Execute(() => new UfDA(config).Add(uf));

        /// <summary>
        /// Atualiza uma UF
        /// </summary>
        /// <param name="uf"></param>
        /// <returns></returns>
        [HttpPut(Name = "UpdateUf")]
        public ActionResult<ResultDataDTO<Uf>> Update(Uf uf)
            => Execute(() => new UfDA(config).Update(uf));

        /// <summary>
        /// Deleta uma UF
        /// </summary>
        /// <param name="sigla"></param>
        /// <returns></returns>
        [HttpDelete(Name = "DeleteUf")]
        public ActionResult<ResultDataDTO<int>> Delete(string sigla)
            => Execute(() => new UfDA(config).Delete(sigla));
    }
}
