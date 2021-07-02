using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Blazored.WebShop.Persistence.SQL.Wrappers.Interfaces;
using Dapper;

namespace Blazored.WebShop.Persistence.SQL.Wrappers
{
    public class DataAccess : IDataAccess
    {
        private readonly string _connectionString;

        public DataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public T QuerySingle<T, TU>(string sqlStatement, TU parameters)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            return connection.QuerySingle<T>(sqlStatement, parameters);
        }

        public T QueryFirst<T, TU>(string sqlStatement, TU parameters)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            return connection.QueryFirst<T>(sqlStatement, parameters);
        }

        public List<T> QueryList<T, TU>(string sqlStatement, TU parameters)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            return connection.Query<T>(sqlStatement, parameters).ToList();
        } 

        public void ExecuteCommand<T>(string sqlStatement, T parameters)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            connection.Execute(sqlStatement, parameters);
        } 
    }
}
