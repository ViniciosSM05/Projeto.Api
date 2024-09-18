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
    public class UsuarioController(IConfiguration config) : BaseController
    {
        /// <summary>
        /// Obtém uma lista de objetos de usuários
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetUsuarios")]
        public ActionResult<ResultDataDTO<IEnumerable<Usuario>>> Get() 
            => Execute(() => new UsuarioDA(config).GetAll());

        /// <summary>
        /// Inclui um novo usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [AllowAnonymous]
        [HttpPost(Name = "AddUsuario")]
        public ActionResult<ResultDataDTO<Usuario>> Add(Usuario usuario)
            => Execute(() => 
            {
                if (string.IsNullOrEmpty(usuario.Nome)) throw new Exception("Nome é obrigatório");
                if (string.IsNullOrEmpty(usuario.Cpfcnpj)) throw new Exception("Documento é obrigatório");
                if (string.IsNullOrEmpty(usuario.Senha)) throw new Exception("Senha é obrigatória");

                return new UsuarioDA(config).Add(usuario);
            });

        /// <summary>
        /// Atualiza um usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPut(Name = "UpdateUsuario")]
        public ActionResult<ResultDataDTO<Usuario>> Update(Usuario usuario)
            => Execute(() => new UsuarioDA(config).Update(usuario));

        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(Name = "DeleteUsuario")]
        public ActionResult<ResultDataDTO<int>> Delete(Guid id)
            => Execute(() => new UsuarioDA(config).Delete(id));
    }
}
