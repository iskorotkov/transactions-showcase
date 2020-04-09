using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Npgsql;

namespace TransactionsShowcase.Db
{
    public class EmpiresManager : IDisposable
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

        public void BeginTransaction(IsolationLevel level = IsolationLevel.ReadCommitted)
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }

            _transaction?.Dispose();
            _transaction = _connection.BeginTransaction(level);
        }

        public void SavePoint(string savePoint)
        {
            _transaction?.Save(savePoint);
        }

        public void Rollback(string savePoint)
        {
            _transaction?.Rollback(savePoint);
        }

        public void Rollback()
        {
            _transaction?.Rollback();
        }

        public IEnumerable<Empire> GetEmpires()
        {
            return _connection.Query<Empire>(@"
                select id, name, ruler, power, government_type_id as GovernmentTypeId
                from empires
                order by id", _transaction);
        }

        public void SetPower(int power)
        {
            _connection.Execute("update empires set power = @power",
                new { power }, _transaction);
        }

        public void SetPower(int id, int power)
        {
            _connection.Execute("update empires set power = @power where id = @id",
                new { id, power }, _transaction);
        }

        public void SetGovId(int id)
        {
            _connection.Execute("update empires set government_type_id = @id",
                new { id }, _transaction);
        }

        public void AddPower(int id, int diff)
        {
            _connection.Execute("update empires set power = power + @diff where id = @id",
                new { id, diff }, _transaction);
        }

        public void AddPower(int diff)
        {
            _connection.Execute("update empires set power = power + @diff",
                new { diff }, _transaction);
        }

        public void Add(Empire empire)
        {
            _connection.Execute(@"
                insert into empires(name, power, government_type_id, ruler)
                values (@name, @power, @govId, @ruler)", new
            {
                name = empire.Name,
                power = empire.Power,
                govId = empire.GovernmentTypeId,
                ruler = empire.Ruler
            }, _transaction);
        }

        public int GetMaxPower()
        {
            return _connection.Query<int>("select max(power) from empires", _transaction)
                .First();
        }

        public int GetMinPower()
        {
            return _connection.Query<int>("select min(power) from empires", _transaction)
                .First();
        }

        public void SetStrongestPower(int power)
        {
            _connection.Execute(@"
                update empires
                set power = @power
                where power = (select max(power) from empires)",
                new { power }, _transaction);
        }

        public void SetWeakestPower(int power)
        {
            _connection.Execute(@"
                update empires
                set power = @power
                where power = (select min(power) from empires)",
                new { power }, _transaction);
        }

        public void SetOneAlliancePower(int power)
        {
            _connection.Execute(@"
                update alliances
                set power = @power
                where id = (select max(id) from alliances)",
                new { power }, _transaction);
        }

        public int GetOneAlliancePower()
        {
            return _connection.Query<int>(@"
                select power
                from alliances
                where id = (select max(id) from alliances)",
                _transaction).First();
        }

        public int GetSumOfPowers()
        {
            return _connection.Query<int>("select sum(power) from empires", _transaction).First();
        }

        public void CommitTransaction()
        {
            _transaction?.Commit();
        }
    }
}
