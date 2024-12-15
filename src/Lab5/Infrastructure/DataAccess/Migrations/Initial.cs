using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        create type transaction_type as enum
        (
            'Withdraw',
            'TopUp'
        );

        create table accounts
        (
            account_number bigint primary key,
            pin_code varchar(4) not null,
            balance numeric(15,2) not null default 0.00
        );

        create table admins 
        (
            system_password varchar(255) not null
        );

        create table transactions
        (
            account_number bigint references accounts(account_number) on delete cascade,
            type transaction_type not null,
            sum numeric(15,2) not null
        );
            
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        drop table transactions;
        drop table admins;
        drop table accounts;
        drop type transaction_type;
        """;
}