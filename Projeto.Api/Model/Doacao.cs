using Dapper.Contrib.Extensions;
using Projeto.Api.Model.Base;

namespace Projeto.Api.Model
{
    [Table("doacao")]
    public class Doacao : BaseModel
    {
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public Guid Anuncio_Id { get; set; }
    }
}
