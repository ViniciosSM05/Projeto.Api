using Dapper;
using Dapper.Contrib.Extensions;
using Projeto.Api.DataAccess.Base;
using Projeto.Api.Model;

namespace Projeto.Api.DataAccess
{
    public class DoacaoDA(IConfiguration config) : BaseDA(config)
    {
        public IEnumerable<Doacao> GetAll()
        {
            using var conexao = GetConnection();
            return conexao.GetAll<Doacao>();    
        }

        public Doacao Add(Doacao doacao)
        {
            using var conexao = GetConnection();
            conexao.Execute(@"
                INSERT INTO doacao(id, valor, data, anuncio_id) 
                VALUES(@id, @valor, @data, @anuncio_id) 
            ", new {
                id = doacao.Id,
                valor = doacao.Valor,
                data = doacao.Data,
                anuncio_id = doacao.Anuncio_Id,
            });
            return doacao;  
        }

        public Doacao Update(Doacao doacao)
        {
            using var conexao = GetConnection();
            conexao.Execute(@"
                UPDATE doacao
                    SET valor = @valor, 
                    data = @data,
                    anuncio_id = @anuncio_id
                WHERE id = @id
            ", new {
                id = doacao.Id,
                valor = doacao.Valor,
                data = doacao.Data,
                anuncio_id = doacao.Anuncio_Id,
            });
            return doacao;
        }

        public int Delete(Guid id)
        {
            using var conexao = GetConnection();
            return conexao.Execute("DELETE FROM doacao WHERE id = @id", new { id });
        }
    }
}
