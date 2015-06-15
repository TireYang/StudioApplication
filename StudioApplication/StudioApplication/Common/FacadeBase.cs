using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;
using DapperExtensions;
using System.Data;
using System.Web;

namespace StudioApplication.Common
{
    public class FacadeBase<T> where T : class
    {
        #region DataBaseConnectionString
        string _connection;
        public string DataBaseConnectionString
        {
            get
            {
                return _connection;
            }
        }
        #endregion

        public FacadeBase(string connection)
        {
            _connection = connection;
        }

        #region Sql Template

        public string GetSqlCountTemplate(string sql)
        {
            return string.Format("select count(*) as Count from ({0})temp", sql);
        }

        #endregion

        //Dapper

        #region Excute

        public int Execute(string sql, dynamic param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var connection = new SqlConnection(_connection))
            {
                connection.Open();
                int result = SqlMapper.Execute(connection, sql, param, transaction, commandTimeout, commandType);
                connection.Close();
                return result;
            }
        }
        #endregion

        #region Query

        public IEnumerable<T> Query(string sql, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var connection = new SqlConnection(_connection))
            {
                connection.Open();
                var result = SqlMapper.Query<T>(connection, sql, param, transaction, buffered, commandTimeout, commandType);
                connection.Close();
                return result;
            }
        }
        public IEnumerable<dynamic> QueryDynamic(string sql, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var connection = new SqlConnection(_connection))
            {
                connection.Open();
                var result = SqlMapper.Query(connection, sql, param, transaction, buffered, commandTimeout, commandType);
                connection.Close();
                return result;
            }
        }
        public IEnumerable<TReturn> Query<TReturn>(string sql, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var connection = new SqlConnection(_connection))
            {
                connection.Open();
                IEnumerable<TReturn> result = SqlMapper.Query<TReturn>(connection, sql, param, transaction, buffered, commandTimeout, commandType);
                connection.Close();
                return result;
            }
        }

        #endregion

        #region Query Multiple
        public SqlMapper.GridReader QueryMultiple(CommandDefinition command)
        {
            using (var connection = new SqlConnection(_connection))
            {
                connection.Open();
                var result = connection.QueryMultiple(command);
                connection.Close();
                return result;
            }
        }

        public dynamic QueryMultiple(string sql, Func<IMultipleResultReader, dynamic> map, dynamic param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var connection = new SqlConnection(_connection))
            {
                connection.Open();
                var reader = SqlMapper.QueryMultiple(connection, sql, param, transaction, commandTimeout, commandType);
                var result = map(reader);
                connection.Close();
                return result;
            }
        }

        #endregion


        //Dapper Extension
        #region Insert
        public dynamic Insert(T entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();
                var result = connection.Insert<T>(entity, transaction, commandTimeout);
                connection.Close();
                return result;
            };
        }
        public void Insert(IEnumerable<T> entities, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();
                connection.Insert<T>(entities, transaction, commandTimeout);
                connection.Close();
            }
        }
        #endregion

        #region Update
        public bool Update(T entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();
                var result = connection.Update<T>(entity, transaction, commandTimeout);
                connection.Close();
                return result;
            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete(new User(){ ID = new Guid("") })
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public bool Delete(T entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();
                var result = connection.Delete<T>(entity, transaction, commandTimeout);
                connection.Close();
                return result;
            }
        }
        public bool Delete(Guid ID, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return Delete(new { ID = ID }, transaction, commandTimeout);
        }
        public bool Delete(string ID, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return Delete(new { ID = ID }, transaction, commandTimeout);
        }
        /// <summary>
        /// Delete(new { ID = "**********"})
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public bool Delete(object predicate, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            if (predicate == null || !predicate.GetType().Name.StartsWith("<>f__AnonymousType"))
            {
                throw new Exception("Predicate must be dynamic value.");//predicate为空 或 非dynamic类型 则抛出异常
            }
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();
                var result = connection.Delete<T>(predicate, transaction, commandTimeout);
                connection.Close();
                return result;
            }
        }
        #endregion

        #region Get GetList
        public T Get(object id)
        {
            if (id == null) { return null; }
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();
                var result = connection.Get<T>(id);
                connection.Close();
                return result;
            }
        }

        /// <summary>
        /// Get(new {ID="xxxxx"})
        /// </summary>
        /// <param name="id"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public T Get(dynamic id, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            if (id == null) { return null; }

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();
                var result = DapperExtensions.DapperExtensions.Get<T>(connection, id, transaction, commandTimeout);
                connection.Close();
                return result;
            }
        }

        /// <summary>
        /// GetList(new {Name="RuiXi Zhou"})
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="sort"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public IEnumerable<T> GetList(object predicate = null, IList<ISort> sort = null, IDbTransaction transaction = null, int? commandTimeout = null, bool buffered = false)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();
                var result = connection.GetList<T>(predicate, sort, transaction, commandTimeout, buffered);
                connection.Close();
                return result;
            }
        }

        #endregion

        #region Count
        /// <summary>
        /// Count("select * from [User] where Name like '%'+@Name+'%'",new {Name="xxx"})
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int Count(string sql, dynamic param)
        {
            using (var connection = new SqlConnection(_connection))
            {
                connection.Open();
                IEnumerable<dynamic> result = SqlMapper.Query<dynamic>(connection, GetSqlCountTemplate(sql), param);
                connection.Close();
                return result.First().Count;
            }
        }
        /// <summary>
        /// Count(new {Name="xxx"})
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public int Count(object predicate, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();
                var result = connection.Count<T>(predicate, transaction, commandTimeout);
                connection.Close();
                return result;
            }
        }
        #endregion

    }
}
