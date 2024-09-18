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
        /// <summary>
        /// Obt�m uma lista de Doa��es
        /// </summary>
        /// <returns>Lista de objetos doa��o</returns>
        [HttpGet(Name = "GetDoacoes")]
        public ActionResult<ResultDataDTO<IEnumerable<Doacao>>> Get()
            => Execute(() => new DoacaoDA(config).GetAll());

        /// <summary>
        /// Inclui uma nova doa��o
        /// </summary>
        /// <param name="doacao"></param>
        /// <returns>Objeto doa��o criado</returns>
        [HttpPost(Name = "AddDoacao")]
        public ActionResult<ResultDataDTO<Doacao>> Add(Doacao doacao)
            => Execute(() => new DoacaoDA(config).Add(doacao));

        /// <summary>
        /// Atualiza uma doa��o
        /// </summary>
        /// <param name="doacao"></param>
        /// <returns>Objeto doa��o atualizado</returns>
        [HttpPut(Name = "UpdateDoacao")]
        public ActionResult<ResultDataDTO<Doacao>> Update(Doacao doacao)
            => Execute(() => new DoacaoDA(config).Update(doacao));

        /// <summary>
        /// Deleta uma doa��o
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(Name = "DeleteDoacao")]
        public ActionResult<ResultDataDTO<int>> Delete(Guid id)
            => Execute(() => new DoacaoDA(config).Delete(id));
    }
}
