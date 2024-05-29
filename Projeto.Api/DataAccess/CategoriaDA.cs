using Dapper;
using Dapper.Contrib.Extensions;
using Projeto.Api.DataAccess.Base;
using Projeto.Api.DTO;
using Projeto.Api.Model;

namespace Projeto.Api.DataAccess
{
    public class CategoriaDA(IConfiguration config) : BaseDA(config)
    {
        public IEnumerable<Categoria> GetAll()
        {
            using var conexao = GetConnection();
            return conexao.GetAll<Categoria>();    
        }

        public Categoria Add(Categoria categoria)
        {
            using var conexao = GetConnection();
            conexao.Execute("INSERT INTO categoria(id, nome) VALUES(@id, @nome)", new {
                id = categoria.Id,
                nome = categoria.Nome,
            });
            return categoria;  
        }

        public Categoria Update(Categoria categoria)
        {
            using var conexao = GetConnection();
            conexao.Execute("UPDATE categoria SET nome = @nome WHERE id = @id", new
            {
                id = categoria.Id,
                nome = categoria.Nome,
            });
            return categoria;
        }

        public int Delete(Guid id)
        {
            using var conexao = GetConnection();
            return conexao.Execute("DELETE FROM categoria WHERE id = @id", new { id });
        }

        public IEnumerable<AnuncioPorCategoriaDTO> GetAnunciosPorCategoria()
        {
            using var conexao = GetConnection();
            return conexao.Query<AnuncioPorCategoriaDTO>(@"
	            SELECT
		            c.nome AS Categoria,
		            COUNT(a.id) AS TotalAnuncio
	            FROM
		            categoria c
		            LEFT JOIN anuncio a ON c.id = a.categoria_id
	            GROUP BY
		            c.nome
	            ORDER BY
		            TotalAnuncio DESC 
            ");
        }
    }
}
