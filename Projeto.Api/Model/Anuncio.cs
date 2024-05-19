using Dapper.Contrib.Extensions;
using Projeto.Api.Model.Base;

namespace Projeto.Api.Model
{
    [Table("anuncio")]
    public class Anuncio : BaseModel
    {
        public int Codigo { get; set; }
        public required string Titulo { get; set; }
        public required string Descricao { get; set; }
        public DateTime Data { get; set; }
        public decimal Meta { get; set; }
        public required string Chave_Pix { get; set; }
        public required string Categoria_Id { get; set; }
        public required string Usuario_Id { get; set; }
    }
}
