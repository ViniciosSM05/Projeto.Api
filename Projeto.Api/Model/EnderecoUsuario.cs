using Dapper.Contrib.Extensions;
using Projeto.Api.Model.Base;

namespace Projeto.Api.Model
{
    [Table("endereco_usuario")]
    public class EnderecoUsuario : BaseModel
    {
        public required string Cep { get; set; }
        public required string Rua { get; set; }
        public required string Bairro { get; set; }
        public required int Numero { get; set; }
        public required Guid Cidade_Id { get; set; }
        public required Guid Usuario_Id { get; set; }
    }
}
