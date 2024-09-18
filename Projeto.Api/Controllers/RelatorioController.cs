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
        [HttpGet]
        [Route("DoacoesPorAnuncio")]
        public ActionResult<ResultDataDTO<IEnumerable<DoacaoPorAnuncioDTO>>> GetDoacoesPorAnuncio()
            => Execute(() => new DoacaoDA(config).GetDoacoesPorAnuncio());

        [HttpGet]
        [Route("AnunciosPorCategoria")]
        public ActionResult<ResultDataDTO<IEnumerable<AnuncioPorCategoriaDTO>>> GetAnunciosPorCategoria()
            => Execute(() => new CategoriaDA(config).GetAnunciosPorCategoria());

        [HttpGet]
        [Route("UsuariosPorCidade")]
        public ActionResult<ResultDataDTO<IEnumerable<UsuarioPorCidadeDTO>>> GetUsuariosPorCidade()
            => Execute(() => new UsuarioDA(config).GetUsuariosPorCidade());

        [HttpGet]
        [Route("AnunciosPorData")]
        public ActionResult<ResultDataDTO<IEnumerable<AnuncioPorDataDTO>>> GetAnunciosPorData()
            => Execute(() => new AnuncioDA(config).GetAnunciosPorData());

        [HttpGet]
        [Route("DoacoesPorUsuario")]
        public ActionResult<ResultDataDTO<IEnumerable<DoacaoPorUsuarioDTO>>> GetDoacoesPorUsuario()
            => Execute(() => new DoacaoDA(config).GetDoacoesPorUsuario());
    }
}
