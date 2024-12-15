using DomainModel.Users.Transaction;
using Itmo.Dev.Platform.Postgres.Plugins;
using Npgsql;

namespace DataAccess.Plugins;

public class MappingPlugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder)
    {
        builder.MapEnum<TransactionType>();
    }
}