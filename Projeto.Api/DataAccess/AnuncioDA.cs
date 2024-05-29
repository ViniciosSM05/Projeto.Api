using Dapper;
using Dapper.Contrib.Extensions;
using Projeto.Api.DataAccess.Base;
using Projeto.Api.DTO;
using Projeto.Api.Model;

namespace Projeto.Api.DataAccess
{
    public class AnuncioDA(IConfiguration config) : BaseDA(config)
    {
        public IEnumerable<Anuncio> GetAll()
        {
            using var conexao = GetConnection();
            return conexao.GetAll<Anuncio>();    
        }

        public Anuncio Add(Anuncio anuncio)
        {
            using var conexao = GetConnection();
            conexao.Execute(@"
                INSERT INTO anuncio(id, codigo, titulo, descricao, data, meta, chave_pix, categoria_id, usuario_id) 
                VALUES(@id, @codigo, @titulo, @descricao, @data, @meta, @chave_pix, @categoria_id, @usuario_id) 
            ", new {
                id = anuncio.Id,
                codigo = anuncio.Codigo,
                titulo = anuncio.Titulo,
                descricao = anuncio.Descricao,
                data = anuncio.Data,
                meta = anuncio.Meta,
                chave_pix = anuncio.Chave_Pix,
                categoria_id = anuncio.Categoria_Id,
                usuario_id = anuncio.Usuario_Id,
            });
            return anuncio;  
        }

        public Anuncio Update(Anuncio anuncio)
        {
            using var conexao = GetConnection();
            conexao.Execute(@"
                UPDATE anuncio
                    SET codigo = @codigo, 
                    titulo = @titulo,
                    descricao = @descricao,
                    data = @data,
                    meta = @meta,
                    chave_pix = @chave_pix,
                    categoria_id = @categoria_id,
                    usuario_id = @usuario_id
                WHERE id = @id
            ", new {
                id = anuncio.Id,
                codigo = anuncio.Codigo,
                titulo = anuncio.Titulo,
                descricao = anuncio.Descricao,
                data = anuncio.Data,
                meta = anuncio.Meta,
                chave_pix = anuncio.Chave_Pix,
                categoria_id = anuncio.Categoria_Id,
                usuario_id = anuncio.Usuario_Id,
            });
            return anuncio;
        }

        public int Delete(Guid id)
        {
            using var conexao = GetConnection();
            return conexao.Execute("DELETE FROM anuncio WHERE id = @id", new { id });
        }

        public IEnumerable<AnuncioPorDataDTO> GetAnunciosPorData()
        {
            using var conexao = GetConnection();
            return conexao.Query<AnuncioPorDataDTO>(@"
                SELECT
                    a.data AS Data,
                    COUNT(a.id) AS TotalAnuncios
                FROM
                    anuncio a
                GROUP BY
                    Data
                ORDER BY
                    Data ASC
            ");
        }
    }
}
