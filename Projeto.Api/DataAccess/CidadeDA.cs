using Dapper;
using Dapper.Contrib.Extensions;
using Projeto.Api.DataAccess.Base;
using Projeto.Api.Model;

namespace Projeto.Api.DataAccess
{
    public class CidadeDA(IConfiguration config) : BaseDA(config)
    {
        public IEnumerable<Cidade> GetAll()
        {
            using var conexao = GetConnection();
            return conexao.GetAll<Cidade>();    
        }

        public Cidade Add(Cidade cidade)
        {
            using var conexao = GetConnection();
            conexao.Execute("INSERT INTO cidade(id, nome, uf) VALUES(@id, @nome, @uf)", new {
                id = cidade.Id,
                nome = cidade.Nome,
                uf = cidade.Uf,
            });
            return cidade;  
        }

        public Cidade Update(Cidade cidade)
        {
            using var conexao = GetConnection();
            conexao.Execute("UPDATE cidade SET nome = @nome, uf = @uf WHERE id = @id", new
            {
                id = cidade.Id,
                nome = cidade.Nome,
                uf = cidade.Uf
            });
            return cidade;
        }

        public int Delete(Guid id)
        {
            using var conexao = GetConnection();
            return conexao.Execute("DELETE FROM cidade WHERE id = @id", new { id });
        }
    }
}
