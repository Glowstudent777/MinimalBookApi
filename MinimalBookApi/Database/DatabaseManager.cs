using MySqlConnector;

namespace MinimalBookApi.Database
{
    public class DatabaseManager
    {
        private readonly MySqlConnection _connection;

        public DatabaseManager(MySqlConnection connection)
        {
            _connection = connection;
        }

        public void OpenConnection()
        {
            _connection.Open();
        }

        public void CloseConnection()
        {
            _connection.Close();
        }

        public MySqlCommand CreateCommand(string query)
        {
            return new MySqlCommand(query, _connection);
        }
    }
}