using Microsoft.AspNetCore.Mvc;
using Projeto.Api.DataAccess;
using Projeto.Api.DTO;

namespace Projeto.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelatorioController(IConfiguration config) : ControllerBase
    {
        [HttpGet]
        [Route("DoacoesPorAnuncio")]
        public IEnumerable<DoacaoPorAnuncioDTO> GetDoacoesPorAnuncio() => new DoacaoDA(config).GetDoacoesPorAnuncio();

        [HttpGet]
        [Route("AnunciosPorCategoria")]
        public IEnumerable<AnuncioPorCategoriaDTO> GetAnunciosPorCategoria() => new CategoriaDA(config).GetAnunciosPorCategoria();

        [HttpGet]
        [Route("UsuariosPorCidade")]
        public IEnumerable<UsuarioPorCidadeDTO> GetUsuariosPorCidade() => new UsuarioDA(config).GetUsuariosPorCidade();

        [HttpGet]
        [Route("AnunciosPorData")]
        public IEnumerable<AnuncioPorDataDTO> GetAnunciosPorData() => new AnuncioDA(config).GetAnunciosPorData();

        [HttpGet]
        [Route("DoacoesPorUsuario")]
        public IEnumerable<DoacaoPorUsuarioDTO> GetDoacoesPorUsuario() => new DoacaoDA(config).GetDoacoesPorUsuario();
    }
}
