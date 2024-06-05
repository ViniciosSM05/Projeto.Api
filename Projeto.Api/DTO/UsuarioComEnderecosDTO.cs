namespace Projeto.Api.DTO
{
    public class UsuarioComEnderecosDTO
    {
        public required string NomeUsuario {  get; set; }
        public string NomeCidade { get; set; }
        public string Sigla { get; set; }
        public int TotalEnderecos { get; set; }
    }
}
