using Abstraction.Repositories;
using DomainModel.Admins;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace DataAccess.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public SystemAdmin? GetSystemAdminByPassword(string password)
    {
        const string sql = """
                           SELECT *
                           FROM admins 
                           WHERE system_password = :password;
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("password", password);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (!reader.Read())
            return null;

        return new SystemAdmin(reader.GetString(0));
    }

    public void UpdateSystemAdmin(SystemAdmin systemAdmin)
    {
        const string deleteSql = "DELETE FROM admins;";
        const string insertSql = """
                                 INSERT INTO admins (system_password)
                                 VALUES (:systemPassword);
                                 """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using (var command = new NpgsqlCommand(deleteSql, connection))
        {
            command.ExecuteNonQuery();
        }

        using (var command = new NpgsqlCommand(insertSql, connection))
        {
            command.AddParameter("systemPassword", systemAdmin.SystemPassword);
            command.ExecuteNonQuery();
        }
    }
}