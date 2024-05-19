using Microsoft.AspNetCore.Mvc;
using Projeto.Api.DataAccess;
using Projeto.Api.Model;

namespace Projeto.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnuncioController(IConfiguration config) : ControllerBase
    {
        [HttpGet(Name = "GetAnuncios")]
        public IEnumerable<Anuncio> Get() => new AnuncioDA(config).GetAll();

        [HttpPost(Name = "AddAnuncio")]
        public Anuncio Add(Anuncio anuncio) => new AnuncioDA(config).Add(anuncio);

        [HttpPut(Name = "UpdateAnuncio")]
        public Anuncio Update(Anuncio anuncio) => new AnuncioDA(config).Update(anuncio);

        [HttpDelete(Name = "DeleteAnuncio")]
        public int Delete(Guid id) => new AnuncioDA(config).Delete(id);
    }
}
