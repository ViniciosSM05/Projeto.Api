using Dapper;
using Dapper.Contrib.Extensions;
using Projeto.Api.DataAccess.Base;
using Projeto.Api.Model;

namespace Projeto.Api.DataAccess
{
    public class EnderecoUsuarioDA(IConfiguration config) : BaseDA(config)
    {
        public IEnumerable<EnderecoUsuario> GetAll()
        {
            using var conexao = GetConnection();
            return conexao.GetAll<EnderecoUsuario>();    
        }

        public EnderecoUsuario Add(EnderecoUsuario endereco)
        {
            using var conexao = GetConnection();
            conexao.Execute(@"
                INSERT INTO endereco_usuario(id, cep, rua, bairro, numero, cidade_id, usuario_id) 
                VALUES(@id, @cep, @rua, @bairro, @numero, @cidade_id, @usuario_id) 
            ", new {
                id = endereco.Id,
                cep = endereco.Cep,
                rua = endereco.Rua,
                bairro = endereco.Bairro,
                numero = endereco.Numero,
                cidade_id = endereco.Cidade_Id,
                usuario_id = endereco.Usuario_Id,
            });
            return endereco;  
        }

        public EnderecoUsuario Update(EnderecoUsuario endereco)
        {
            using var conexao = GetConnection();
            conexao.Execute(@"
                UPDATE endereco_usuario 
                    SET cep = @cep, 
                    rua = @rua, 
                    bairro = @bairro, 
                    numero = @numero, 
                    cidade_id = @cidade_id,
                    usuario_id = @usuario_id
                WHERE id = @id
            ", new {
                id = endereco.Id,
                cep = endereco.Cep,
                rua = endereco.Rua,
                bairro = endereco.Bairro,
                numero = endereco.Numero,
                cidade_id = endereco.Cidade_Id,
                usuario_id = endereco.Usuario_Id,
            });
            return endereco;
        }

        public int Delete(Guid id)
        {
            using var conexao = GetConnection();
            return conexao.Execute("DELETE FROM endereco_usuario WHERE id = @id", new { id });
        }
    }
}
