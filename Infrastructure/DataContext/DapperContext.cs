using Npgsql;

namespace Infrastructure.DataContext;

public interface IContext
{
    NpgsqlConnection Connection();
}

public class DapperContext : IContext
{
    private readonly string connectionString =
        "Server=localhost; Port = 5432; Database = JobBoardManagement; User Id = postgres; Password = LMard1909;";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(connectionString);
    }
}
