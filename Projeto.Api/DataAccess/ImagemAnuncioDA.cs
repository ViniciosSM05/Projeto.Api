using Dapper;
using Dapper.Contrib.Extensions;
using Projeto.Api.DataAccess.Base;
using Projeto.Api.Model;

namespace Projeto.Api.DataAccess
{
    public class ImagemAnuncioDA(IConfiguration config) : BaseDA(config)
    {
        public IEnumerable<ImagemAnuncio> GetAll()
        {
            using var conexao = GetConnection();
            return conexao.GetAll<ImagemAnuncio>();    
        }

        public ImagemAnuncio Add(ImagemAnuncio imagem)
        {
            using var conexao = GetConnection();
            conexao.Execute(@"
                INSERT INTO imagem_anuncio(id, principal, url, anuncio_id) 
                VALUES(@id, @principal, @url, @anuncio_id) 
            ", new {
                id = imagem.Id,
                principal = imagem.Principal,
                url = imagem.Url,
                anuncio_id = imagem.Anuncio_Id,
            });
            return imagem;  
        }

        public ImagemAnuncio Update(ImagemAnuncio imagem)
        {
            using var conexao = GetConnection();
            conexao.Execute(@"
                UPDATE imagem_anuncio
                    SET principal = @principal, 
                    url = @url,
                    anuncio_id = @anuncio_id
                WHERE id = @id
            ", new {
                id = imagem.Id,
                principal = imagem.Principal,
                url = imagem.Url,
                anuncio_id = imagem.Anuncio_Id,
            });
            return imagem;
        }

        public int Delete(Guid id)
        {
            using var conexao = GetConnection();
            return conexao.Execute("DELETE FROM imagem_anuncio WHERE id = @id", new { id });
        }
    }
}
