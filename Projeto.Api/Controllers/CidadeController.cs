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
        /// <summary>
        /// Obtém todas as cidades
        /// </summary>
        /// <returns>Lista de objetos cidades</returns>
        [HttpGet(Name = "GetCidades")]
        public ActionResult<ResultDataDTO<IEnumerable<Cidade>>> Get()
            => Execute(() => new CidadeDA(config).GetAll());

        /// <summary>
        /// Inclui uma nova cidade
        /// </summary>
        /// <param name="cidade"></param>
        /// <returns>Objeto da cidade criado</returns>
        [HttpPost(Name = "AddCidade")]
        public ActionResult<ResultDataDTO<Cidade>> Add(Cidade cidade)
           => Execute(() => new CidadeDA(config).Add(cidade));

        /// <summary>
        /// Atualiza uma cidade
        /// </summary>
        /// <param name="cidade"></param>
        /// <returns>Objeto da cidade atualizado</returns>
        [HttpPut(Name = "UpdateCidade")]
        public ActionResult<ResultDataDTO<Cidade>> Update(Cidade cidade)
            => Execute(() => new CidadeDA(config).Update(cidade));

        /// <summary>
        /// Deleta uma cidade
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(Name = "DeleteCidade")]
        public ActionResult<ResultDataDTO<int>> Delete(Guid id)
            => Execute(() => new CidadeDA(config).Delete(id));
    }
}
