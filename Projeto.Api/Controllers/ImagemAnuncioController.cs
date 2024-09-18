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
    public class ImagemAnuncioController(IConfiguration config) : BaseController
    {
        /// <summary>
        /// Obtém uma lista de imagens de um anuncio
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetImagemAnuncios")]
        public ActionResult<ResultDataDTO<IEnumerable<ImagemAnuncio>>> Get()
            => Execute(() => new ImagemAnuncioDA(config).GetAll());

        /// <summary>
        /// Inclui uma imagem ao anuncio
        /// </summary>
        /// <param name="imagem"></param>
        /// <returns></returns>
        [HttpPost(Name = "AddImagemAnuncio")]
        public ActionResult<ResultDataDTO<ImagemAnuncio>> Add(ImagemAnuncio imagem)
            => Execute(() => new ImagemAnuncioDA(config).Add(imagem));

        /// <summary>
        /// Atualiza uma imagem do anuncio
        /// </summary>
        /// <param name="doacao"></param>
        /// <returns></returns>
        [HttpPut(Name = "UpdateImagemAnuncio")]
        public ActionResult<ResultDataDTO<ImagemAnuncio>> Update(ImagemAnuncio doacao)
            => Execute(() => new ImagemAnuncioDA(config).Update(doacao));

        /// <summary>
        /// Deleta uma imagem do anuncio
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(Name = "DeleteImagemAnuncio")]
        public ActionResult<ResultDataDTO<int>> Delete(Guid id)
            => Execute(() => new ImagemAnuncioDA(config).Delete(id));
    }
}
