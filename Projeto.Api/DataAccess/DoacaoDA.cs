using Dapper;
using Dapper.Contrib.Extensions;
using Projeto.Api.DataAccess.Base;
using Projeto.Api.DTO;
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

        public IEnumerable<DoacaoPorAnuncioDTO> GetDoacoesPorAnuncio()
        {
            using var conexao = GetConnection();
            return conexao.Query<DoacaoPorAnuncioDTO>(@"
                SELECT
                    a.titulo AS Titulo,
                    SUM(d.valor) AS TotalDoado
                FROM
                    anuncio a
                    JOIN doacao d ON a.id = d.anuncio_id
                GROUP BY
                    a.titulo
                ORDER BY
                    TotalDoado DESC
            ");
        }

        public IEnumerable<DoacaoPorUsuarioDTO> GetDoacoesPorUsuario()
        {
            using var conexao = GetConnection();
            return conexao.Query<DoacaoPorUsuarioDTO>(@"
                SELECT
                    u.nome AS Nome,
                    SUM(d.valor) AS TotalDoado
                FROM
                    usuario u
                    JOIN anuncio a ON u.id = a.usuario_id
                    JOIN doacao d ON a.id = d.anuncio_id
                GROUP BY
                    Nome
                ORDER BY
                    TotalDoado DESC
            ");
        }
    }
}
