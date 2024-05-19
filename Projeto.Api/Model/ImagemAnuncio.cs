using Dapper.Contrib.Extensions;
using Projeto.Api.Model.Base;

namespace Projeto.Api.Model
{
    [Table("imagem_anuncio")]
    public class ImagemAnuncio : BaseModel
    {
        public bool Principal { get; set; }
        public required string Url { get; set; }
        public Guid Anuncio_Id { get; set; }
    }
}
