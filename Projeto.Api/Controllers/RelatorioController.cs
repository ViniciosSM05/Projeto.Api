using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto.Api.Controllers.Base;
using Projeto.Api.DataAccess;
using Projeto.Api.DTO;

namespace Projeto.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class RelatorioController(IConfiguration config) : BaseController
    {
        /// <summary>
        /// Obtém um relatório de todas as doações por anuncio
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("DoacoesPorAnuncio")]
        public ActionResult<ResultDataDTO<IEnumerable<DoacaoPorAnuncioDTO>>> GetDoacoesPorAnuncio()
            => Execute(() => new DoacaoDA(config).GetDoacoesPorAnuncio());

        /// <summary>
        /// Obtém um relatório de todos os anuncios de uma categoria
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AnunciosPorCategoria")]
        public ActionResult<ResultDataDTO<IEnumerable<AnuncioPorCategoriaDTO>>> GetAnunciosPorCategoria()
            => Execute(() => new CategoriaDA(config).GetAnunciosPorCategoria());

        /// <summary>
        /// Obtém um relatório de usuários de uma cidade
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("UsuariosPorCidade")]
        public ActionResult<ResultDataDTO<IEnumerable<UsuarioPorCidadeDTO>>> GetUsuariosPorCidade()
            => Execute(() => new UsuarioDA(config).GetUsuariosPorCidade());

        /// <summary>
        /// Obtém um relatório de anuncios por uma data específica
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AnunciosPorData")]
        public ActionResult<ResultDataDTO<IEnumerable<AnuncioPorDataDTO>>> GetAnunciosPorData()
            => Execute(() => new AnuncioDA(config).GetAnunciosPorData());

        /// <summary>
        /// Obtém um relatório de doações por usuário
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("DoacoesPorUsuario")]
        public ActionResult<ResultDataDTO<IEnumerable<DoacaoPorUsuarioDTO>>> GetDoacoesPorUsuario()
            => Execute(() => new DoacaoDA(config).GetDoacoesPorUsuario());
    }
}
