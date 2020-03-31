using System;
using System.Data;
using System.Linq;
using Dapper;
using Npgsql;

namespace TransactionsShowcase.Db
{
    class StarTypeManager : IDisposable
    {
        private readonly NpgsqlConnection _connection;
        private NpgsqlTransaction _transaction;

        public StarTypeManager()
        {
            _connection = new NpgsqlConnection(Settings.Default.ConnectionString);
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _connection?.Dispose();
        }

        public void BeginTransaction()
        {
            _connection.Open();
            _transaction = _connection.BeginTransaction(IsolationLevel.Serializable);
        }

        public bool Exists(string name)
        {
            return _connection
                .Query<bool>("select exists(select * from star_types where name = @name)",
                    new { name }, _transaction)
                .First();
        }

        public void Add(string name)
        {
            _connection.Execute("insert into star_types(name) values (@name)",
                new { name }, _transaction);
            _transaction.Commit();
        }
    }
}