using Dapper.Contrib.Extensions;
using Projeto.Api.Model.Base;

namespace Projeto.Api.Model
{
    [Table("cidade")]
    public class Cidade : BaseModel
    {
        public required string Nome { get; set; }
        public required string Uf { get; set; }
    }
}
