using Dapper.Contrib.Extensions;
using Projeto.Api.Model.Base;

namespace Projeto.Api.Model
{
    [Table("categoria")]
    public class Categoria : BaseModel
    {
        public required string Nome { get; set; }
    }
}
