using Projeto.Api.Model;

namespace Projeto.Api.Services.Token
{
    public interface ITokenService
    {
        string GenerateToken(Usuario user);
    }
}
