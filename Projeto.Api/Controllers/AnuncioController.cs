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
        [HttpGet(Name = "GetAnuncios")]
        public ActionResult<ResultDataDTO<IEnumerable<Anuncio>>> Get()
            => Execute(() => new AnuncioDA(config).GetAll());

        [HttpPost(Name = "AddAnuncio")]
        public ActionResult<ResultDataDTO<Anuncio>> Add(Anuncio anuncio)
            => Execute(() => new AnuncioDA(config).Add(anuncio));

        [HttpPut(Name = "UpdateAnuncio")]
        public ActionResult<ResultDataDTO<Anuncio>> Update(Anuncio anuncio)
            => Execute(() => new AnuncioDA(config).Update(anuncio));

        [HttpDelete(Name = "DeleteAnuncio")]
        public ActionResult<ResultDataDTO<int>> Delete(Guid id)
            => Execute(() => new AnuncioDA(config).Delete(id));
    }
}
