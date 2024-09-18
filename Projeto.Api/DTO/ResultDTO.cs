namespace Projeto.Api.DTO
{
    public class ResultDTO
    {
        public ResultDTO() { }
        public ResultDTO(string error) => SetError(error);
        public ResultDTO(Exception exception) => SetError(exception);

        public string Error { get; private set; }
        public bool Success => string.IsNullOrWhiteSpace(Error);

        public ResultDTO SetError(string error)
        {
            Error = error;
            return this;
        }

        public ResultDTO SetError(Exception exception)
        {
            Error = exception.Message;
            return this;
        }
    }
}
