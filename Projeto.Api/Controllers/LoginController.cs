using Microsoft.AspNetCore.Mvc;
using Projeto.Api.Controllers.Base;
using Projeto.Api.DataAccess;
using Projeto.Api.DTO;
using Projeto.Api.Services.Token;

namespace Projeto.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController(ITokenService tokenService, IConfiguration config) : BaseController
    {
        [HttpPost]
        public ActionResult<ResultDataDTO<string>> Login(UsuarioParaLoginDto param)
            => Execute(() =>
            {
                var usuario = new UsuarioDA(config).GetUsuarioPorEmailESenha(param.Email, param.Senha);
                return usuario == null ? throw new Exception("Usuário não encontrado") : tokenService.GenerateToken(usuario);
            });
    }
}
