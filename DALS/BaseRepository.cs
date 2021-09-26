using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALS
{
    public class BaseRepository
    {
        private string ConnectionString { get; set; }

        public BaseRepository(string db)
        {
            ConnectionString = @$"Data Source={db};";
        }

        private IDbConnection NewConnection() => new SqliteConnection(ConnectionString);

        #region async
        protected async Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param = null)
        {
            using (var conn = NewConnection())
            {
                return await conn.QuerySingleOrDefaultAsync<T>(sql, param);
            }
        }

        protected async Task<T> QuerySingleAsync<T>(string sql, object param = null)
        {
            using (var conn = NewConnection())
            {
                return await conn.QuerySingleAsync<T>(sql, param);
            }
        }

        protected async Task<T> QueryFirstAsync<T>(string sql, object param = null)
        {
            using (var conn = NewConnection())
            {
                return await conn.QueryFirstAsync<T>(sql, param);
            }
        }

        protected async Task<List<T>> QueryAsync<T>(string sql, object param = null)
        {
            using (var conn = NewConnection())
            {
                var result = await conn.QueryAsync<T>(sql, param);

                return result.ToList();
            }
        }

        protected async Task<int> ExecuteAsync(string sql, object param = null)
        {
            using (var conn = NewConnection())
            {
                return await conn.ExecuteAsync(sql, param);
            }
        }

        protected async Task QueryMultipleAsync(string sql, Action<SqlMapper.GridReader> map, object param = null)
        {
            using (var conn = NewConnection())
            {
                var result = await conn.QueryMultipleAsync(sql, param);

                map(result);
            }
        }
        #endregion

        #region sync
        protected T QuerySingleOrDefault<T>(string sql, object param = null)
        {
            using (var conn = NewConnection())
            {
                return conn.QuerySingleOrDefault<T>(sql, param);
            }
        }

        protected T QuerySingle<T>(string sql, object param = null)
        {
            using (var conn = NewConnection())
            {
                return conn.QuerySingle<T>(sql, param);
            }
        }

        protected List<T> Query<T>(string sql, object param = null)
        {
            using (var conn = NewConnection())
            {
                var result = conn.Query<T>(sql, param);

                return result.ToList();
            }
        }

        protected int Execute(string sql, object param = null)
        {
            using (var conn = NewConnection())
            {
                return conn.Execute(sql, param);
            }
        }

        protected void QueryMultiple(string sql, Action<SqlMapper.GridReader> map, object param = null)
        {
            using (var conn = NewConnection())
            {
                var reader = conn.QueryMultiple(sql, param);
                map(reader);
            }
        }
        #endregion
    }
}
