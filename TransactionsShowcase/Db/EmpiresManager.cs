using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Npgsql;

namespace TransactionsShowcase.Db
{
    class EmpiresManager : IDisposable
    {
        private readonly NpgsqlConnection _connection;
        private NpgsqlTransaction _transaction;

        public EmpiresManager()
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
            _transaction = _connection.BeginTransaction(IsolationLevel.RepeatableRead);
        }

        public void Add(string name, string ruler, int govId, int power)
        {
            _connection.Execute(
                "insert into empires(name, ruler, government_type_id, power) values(@name, @ruler, @govId, @power)",
                new { name, ruler, govId, power });
        }

        public IEnumerable<Empires> GetEmpires()
        {
            return _connection.Query<Empires>("select * from empires", _transaction);
        }

        public IEnumerable<Empires> GetEmpiresWithRuler()
        {
            return _connection.Query<Empires>("select * from empires where ruler is not null", _transaction);
        }

        public void CommitTransaction()
        {
            _transaction?.Commit();
        }
    }
}