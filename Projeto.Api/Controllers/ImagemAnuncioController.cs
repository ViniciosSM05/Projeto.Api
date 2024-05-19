using Microsoft.AspNetCore.Mvc;
using Projeto.Api.DataAccess;
using Projeto.Api.Model;

namespace Projeto.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImagemAnuncioController(IConfiguration config) : ControllerBase
    {
        [HttpGet(Name = "GetImagemAnuncios")]
        public IEnumerable<ImagemAnuncio> Get() => new ImagemAnuncioDA(config).GetAll();

        [HttpPost(Name = "AddImagemAnuncio")]
        public ImagemAnuncio Add(ImagemAnuncio imagem) => new ImagemAnuncioDA(config).Add(imagem);

        [HttpPut(Name = "UpdateImagemAnuncio")]
        public ImagemAnuncio Update(ImagemAnuncio doacao) => new ImagemAnuncioDA(config).Update(doacao);

        [HttpDelete(Name = "DeleteImagemAnuncio")]
        public int Delete(Guid id) => new ImagemAnuncioDA(config).Delete(id);
    }
}
