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
    public class AnuncioController(IConfiguration config) : BaseController
    {
        /// <summary>
        /// Obtém uma lista de Anuncios
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Uma lista de objetos Anuncio</returns>
        [HttpGet(Name = "GetAnuncios")]
        public ActionResult<ResultDataDTO<IEnumerable<Anuncio>>> Get()
            => Execute(() => new AnuncioDA(config).GetAll());

        /// <summary>
        /// Inclui um novo anuncio
        /// </summary>
        /// <param name="anuncio"></param>
        /// <returns>O objeto Anuncio incluido</returns>
        [HttpPost(Name = "AddAnuncio")]
        public ActionResult<ResultDataDTO<Anuncio>> Add(Anuncio anuncio)
            => Execute(() => new AnuncioDA(config).Add(anuncio));

        /// <summary>
        /// Atualiza um anuncio
        /// </summary>
        /// <param name="anuncio"></param>
        /// <returns>O objeto do anuncio atualizado</returns>
        [HttpPut(Name = "UpdateAnuncio")]
        public ActionResult<ResultDataDTO<Anuncio>> Update(Anuncio anuncio)
            => Execute(() => new AnuncioDA(config).Update(anuncio));

        /// <summary>
        /// Deleta um anuncio
        /// </summary>
        /// <param name="anuncio"></param>
        /// <returns>O objeto do anuncio deletado</returns>
        [HttpDelete(Name = "DeleteAnuncio")]
        public ActionResult<ResultDataDTO<int>> Delete(Guid id)
            => Execute(() => new AnuncioDA(config).Delete(id));
    }
}
