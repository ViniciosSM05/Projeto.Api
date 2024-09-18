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
        /// Obt�m um relat�rio de todas as doa��es por anuncio
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("DoacoesPorAnuncio")]
        public ActionResult<ResultDataDTO<IEnumerable<DoacaoPorAnuncioDTO>>> GetDoacoesPorAnuncio()
            => Execute(() => new DoacaoDA(config).GetDoacoesPorAnuncio());

        /// <summary>
        /// Obt�m um relat�rio de todos os anuncios de uma categoria
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AnunciosPorCategoria")]
        public ActionResult<ResultDataDTO<IEnumerable<AnuncioPorCategoriaDTO>>> GetAnunciosPorCategoria()
            => Execute(() => new CategoriaDA(config).GetAnunciosPorCategoria());

        /// <summary>
        /// Obt�m um relat�rio de usu�rios de uma cidade
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("UsuariosPorCidade")]
        public ActionResult<ResultDataDTO<IEnumerable<UsuarioPorCidadeDTO>>> GetUsuariosPorCidade()
            => Execute(() => new UsuarioDA(config).GetUsuariosPorCidade());

        /// <summary>
        /// Obt�m um relat�rio de anuncios por uma data espec�fica
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AnunciosPorData")]
        public ActionResult<ResultDataDTO<IEnumerable<AnuncioPorDataDTO>>> GetAnunciosPorData()
            => Execute(() => new AnuncioDA(config).GetAnunciosPorData());

        /// <summary>
        /// Obt�m um relat�rio de doa��es por usu�rio
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("DoacoesPorUsuario")]
        public ActionResult<ResultDataDTO<IEnumerable<DoacaoPorUsuarioDTO>>> GetDoacoesPorUsuario()
            => Execute(() => new DoacaoDA(config).GetDoacoesPorUsuario());
    }
}
