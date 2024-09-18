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
        [HttpGet(Name = "GetImagemAnuncios")]
        public ActionResult<ResultDataDTO<IEnumerable<ImagemAnuncio>>> Get()
            => Execute(() => new ImagemAnuncioDA(config).GetAll());

        [HttpPost(Name = "AddImagemAnuncio")]
        public ActionResult<ResultDataDTO<ImagemAnuncio>> Add(ImagemAnuncio imagem)
            => Execute(() => new ImagemAnuncioDA(config).Add(imagem));

        [HttpPut(Name = "UpdateImagemAnuncio")]
        public ActionResult<ResultDataDTO<ImagemAnuncio>> Update(ImagemAnuncio doacao)
            => Execute(() => new ImagemAnuncioDA(config).Update(doacao));

        [HttpDelete(Name = "DeleteImagemAnuncio")]
        public ActionResult<ResultDataDTO<int>> Delete(Guid id)
            => Execute(() => new ImagemAnuncioDA(config).Delete(id));
    }
}
