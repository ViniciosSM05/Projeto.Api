using Dapper.Contrib.Extensions;

namespace Projeto.Api.Model.Base
{
    public abstract class BaseModel
    {
        protected BaseModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
    }
}
