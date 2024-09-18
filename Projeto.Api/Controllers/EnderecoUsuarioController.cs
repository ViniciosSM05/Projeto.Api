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
    public class EnderecoUsuarioController(IConfiguration config) : BaseController
    {
        /// <summary>
        /// Obtém uma lista de endereços por usuários
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetEnderecoUsuarios")]
        public ActionResult<ResultDataDTO<IEnumerable<EnderecoUsuario>>> Get()
            => Execute(() => new EnderecoUsuarioDA(config).GetAll());

        /// <summary>
        /// Inclui um endereço para o usuário
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns></returns>
        [HttpPost(Name = "AddEnderecoUsuario")]
        public ActionResult<ResultDataDTO<EnderecoUsuario>> Add(EnderecoUsuario endereco)
            => Execute(() => new EnderecoUsuarioDA(config).Add(endereco));

        /// <summary>
        /// Atualiza um endereço do usuário
        /// </summary>
        /// <param name="uf"></param>
        /// <returns></returns>
        [HttpPut(Name = "UpdateEnderecoUsuario")]
        public ActionResult<ResultDataDTO<EnderecoUsuario>> Update(EnderecoUsuario uf)
            => Execute(() => new EnderecoUsuarioDA(config).Update(uf));

        /// <summary>
        /// Deleta um endereço do usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(Name = "DeleteEnderecoUsuario")]
        public ActionResult<ResultDataDTO<int>> Delete(Guid id)
            => Execute(() => new EnderecoUsuarioDA(config).Delete(id));
    }
}
