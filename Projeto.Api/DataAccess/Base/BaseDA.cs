using MySqlConnector;

namespace Projeto.Api.DataAccess.Base
{
    public abstract class BaseDA(IConfiguration config)
    {
        private const string NameConnectionString = "Default";
        public MySqlConnection GetConnection() => new(config.GetConnectionString(NameConnectionString));
    }
}
