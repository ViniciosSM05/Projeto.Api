namespace Projeto.Api.DTO
{
    public class ResultDataDTO<TData> : ResultDTO
    {
        public ResultDataDTO() { }
        public ResultDataDTO(TData data) => SetData(data);

        public TData Data { get; private set; }

        public ResultDataDTO<TData> SetData(TData data)
        {
            Data = data;
            return this;
        }
    }
}
