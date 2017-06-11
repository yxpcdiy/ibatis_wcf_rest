using IBatisNet.DataMapper;
using ibatisPersistence.DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ibatisPersistence
{
    public class SqlMapDao
    {
        private ISqlMapper _sqlReaderMapper;
        private ISqlMapper _sqlWriterMapper;

        public ISqlMapper GetSqlReaderDao()
        {
            return _sqlReaderMapper;
        }
        public ISqlMapper GetSqlWriterDao()
        {
            return _sqlWriterMapper;
        }

        private SqlMapperFactory _sqlMapperFactory;

        public SqlMapDao(SqlMapperFactory commonMapperFactory)
        {
            _sqlMapperFactory = commonMapperFactory;
            _sqlReaderMapper = _sqlMapperFactory.GetSqlReaderDao();
            _sqlWriterMapper = _sqlMapperFactory.GetSqlWriterDao();
        }

        protected virtual Int64 Insert(string statementName, object parameterObject)
        {
            lock (this)
            {
                Int64 count = 0;
                try
                {
                    object objCount = _sqlWriterMapper.Insert(statementName, parameterObject);
                    count = objCount == null ? 0 : Convert.ToInt64(objCount);
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
                return count;
            }
        }

        protected virtual Int64 Update(string statementName, object parameterObject)
        {
            lock (this)
            {
                Int64 count = 0;
                try
                {
                    count = _sqlWriterMapper.Update(statementName, parameterObject);
                }
                catch (Exception ex)
                {
                    throw(ex);
                }
                return count;
            }
        }

        protected virtual Int64 Delete(string statementName, object parameterObject)
        {
            lock (this)
            {
                Int64 count = _sqlWriterMapper.Delete(statementName, parameterObject);
                //Application.DoEvents();
                return count;
            }
        }

        /// <summary>
        /// 执行复杂查询
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="statementName">操作名</param>
        /// <param name="parameterObject">参数</param>
        /// <returns>实例列表</returns>
        protected virtual IList<T> ExecuteQueryForList<T>(string statementName, object parameterObject)
        {
            IList<T> List = null;
            lock (this)
            {
                try
                {
                    List = _sqlReaderMapper.QueryForList<T>(statementName, parameterObject);
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
                return List;
            }
            //Application.DoEvents();
            
        }

        /// <summary>
        /// 执行复杂查询得到指定数量记录
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="statementName">操作名</param>
        /// <param name="parameterObject">参数</param>
        /// <param name="skipResults">跳过记录数</param>
        /// <param name="maxResults">最多返回记录数</param>
        /// <returns></returns>
        protected virtual IList<T> ExecuteQueryForList<T>(string statementName, object parameterObject, int skipResults, int maxResults)
        {
            lock (this)
            {
                IList<T> List = _sqlReaderMapper.QueryForList<T>(statementName, parameterObject, skipResults, maxResults);
                //Application.DoEvents();
                return List;
            }
        }

        /// <summary>
        /// 得到分页列表
        /// </summary>
        /// <param name="statementName">操作名</param>
        /// <param name="parameterObject">参数</param>
        /// <param name="pageSize">页记录</param>
        /// <returns>分页数据</returns>
        //protected virtual IPaginatedList ExecuteQueryForPaginatedList(string statementName, object parameterObject, Int64 pageSize)
        //{
        //    return _sqlMapper.QueryForPaginatedList(statementName, parameterObject, pageSize);

        //}

        /// <summary>
        /// 执行复杂查询得到单一实例
        /// </summary>
        /// <typeparam name="T">实例类型</typeparam>
        /// <param name="statementName">操作名</param>
        /// <param name="paramenterObject">参数</param>
        /// <returns>实例</returns>
        protected virtual T ExecuteQueryForObject<T>(string statementName, object paramenterObject)
        {
            lock (this)
            {
                return _sqlReaderMapper.QueryForObject<T>(statementName, paramenterObject);
            }
        }

        protected virtual IDictionary ExecuteQueryFogrDictionary(string statementName, object paramenterObject, string keyProperty)
        {
            lock (this)
            {
                return _sqlReaderMapper.QueryForDictionary(statementName, paramenterObject, keyProperty);
            }
        }

        protected virtual IDictionary<TKey, TValue> ExecuteQueryForDictionary<TKey, TValue>(string statementName, object paramenterObject, string keyProperty)
        {
            lock (this)
            {
                //return sqlmap.QueryForDictionary<TKey, TValue>(statementName, paramenterObject, keyProperty);
                return null;
            }
        }
    }
}
