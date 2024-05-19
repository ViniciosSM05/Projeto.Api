using Microsoft.AspNetCore.Mvc;
using Projeto.Api.DataAccess;
using Projeto.Api.Model;

namespace Projeto.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController(IConfiguration config) : ControllerBase
    {
        [HttpGet(Name = "GetCategorias")]
        public IEnumerable<Categoria> Get() => new CategoriaDA(config).GetAll();

        [HttpPost(Name = "AddCategoria")]
        public Categoria Add(Categoria categoria) => new CategoriaDA(config).Add(categoria);

        [HttpPut(Name = "UpdateCategoria")]
        public Categoria Update(Categoria categoria) => new CategoriaDA(config).Update(categoria);

        [HttpDelete(Name = "DeleteCategoria")]
        public int Delete(Guid id) => new CategoriaDA(config).Delete(id);
    }
}
