using Dapper;
using Dapper.Contrib.Extensions;
using Projeto.Api.DataAccess.Base;
using Projeto.Api.Model;

namespace Projeto.Api.DataAccess
{
    public class UfDA(IConfiguration config) : BaseDA(config)
    {
        public IEnumerable<Uf> GetAll()
        {
            using var conexao = GetConnection();
            return conexao.GetAll<Uf>();    
        }

        public Uf Add(Uf uf)
        {
            using var conexao = GetConnection();
            conexao.Execute("INSERT INTO uf(sigla, nome) VALUES(@sigla, @nome)", new {
                sigla = uf.Sigla,
                nome = uf.Nome,
            });
            return uf;  
        }

        public Uf Update(Uf uf)
        {
            using var conexao = GetConnection();
            conexao.Execute("UPDATE uf SET sigla = @sigla, nome = @nome WHERE sigla = @sigla", new
            {
                sigla = uf.Sigla,
                nome = uf.Nome,
            });
            return uf;
        }

        public int Delete(string sigla)
        {
            using var conexao = GetConnection();
            return conexao.Execute("DELETE FROM uf WHERE sigla = @sigla", new { sigla });
        }
    }
}
