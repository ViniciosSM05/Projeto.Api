using Microsoft.AspNetCore.Mvc;
using Projeto.Api.DataAccess;
using Projeto.Api.Model;

namespace Projeto.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController(IConfiguration config) : ControllerBase
    {
        /// <summary>
        /// Obtém uma lista de categorias
        /// </summary>
        /// <returns>Uma lista de objetos categoria</returns>
        [HttpGet(Name = "GetCategorias")]
        public IEnumerable<Categoria> Get() => new CategoriaDA(config).GetAll();

        /// <summary>
        /// Inclui uma nova categoria
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns>Objeto da categoria criada</returns>
        [HttpPost(Name = "AddCategoria")]
        public Categoria Add(Categoria categoria) => new CategoriaDA(config).Add(categoria);

        /// <summary>
        /// Atualiza uma categoria
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns>Objeto da categoria atualizada</returns>
        [HttpPut(Name = "UpdateCategoria")]
        public Categoria Update(Categoria categoria) => new CategoriaDA(config).Update(categoria);

        /// <summary>
        /// Deleta uma categoria
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(Name = "DeleteCategoria")]
        public int Delete(Guid id) => new CategoriaDA(config).Delete(id);
    }
}
