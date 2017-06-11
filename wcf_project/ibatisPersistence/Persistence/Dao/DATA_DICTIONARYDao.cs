using ibatisModel.Entry;
using IBatisNet.DataMapper;
using ibatisPersistence.DataAccess;
using ibatisPersistence.Persistence.IDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ibatisPersistence.Persistence.Dao
{
    public partial class DATA_DICTIONARYDao : SqlMapDao, IDATA_DICTIONARYDao
    {
        public ISqlMapper SqlWriterDao
        {
            get { return GetSqlReaderDao(); }
        }
        public ISqlMapper SqlReaderDao
        {
            get { return GetSqlReaderDao(); }
        }

        public DATA_DICTIONARYDao(SqlMapperFactory commonMapperFactory)
            : base(commonMapperFactory)
        {

        }

        public Int64 GetCount()
        {
            String stmtId = "DATA_DICTIONARY.GetCount";
            Int64 result = base.ExecuteQueryForObject<Int64>(stmtId, null);
            return result;
        }

        /// <summary>Finds a <see cref="DATA_DICTIONARY"/> instance by the primary key value.</summary>
        public DATA_DICTIONARY Find(string dICTIONARY_ID)
        {
            String stmtId = "DATA_DICTIONARY.Find";
            DATA_DICTIONARY result = base.ExecuteQueryForObject<DATA_DICTIONARY>(stmtId, dICTIONARY_ID);
            return result;
        }


        /// <summary>Finds all DATA_DICTIONARY instances.</summary>
        public IList<DATA_DICTIONARY> FindAll()
        {
            String stmtId = "DATA_DICTIONARY.FindAll";
            IList<DATA_DICTIONARY> result = base.ExecuteQueryForList<DATA_DICTIONARY>(stmtId, null);
            return result;
        }

        /// <summary>Inserts a new DATA_DICTIONARY instance into underlying database table.</summary>
        public Int64 Insert(DATA_DICTIONARY obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "DATA_DICTIONARY.Insert";
            return base.Insert(stmtId, obj);
        }

        /// <summary>Update the underlying database record of a DATA_DICTIONARY instance.</summary>
        public Int64 Update(DATA_DICTIONARY obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "DATA_DICTIONARY.Update";
            return base.Update(stmtId, obj);
        }

        /// <summary>Delete the underlying database record of a DATA_DICTIONARY instance.</summary>
        public Int64 Delete(DATA_DICTIONARY obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "DATA_DICTIONARY.Delete";
            return base.Delete(stmtId, obj);
        }
    }
}
