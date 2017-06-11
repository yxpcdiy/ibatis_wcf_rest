using ibatisModel.Entry;
using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ibatisPersistence.Persistence.IDao
{
    public partial interface IDATA_DICTIONARYDao
    {
        ISqlMapper SqlWriterDao { get; }
        ISqlMapper SqlReaderDao { get; }

        /// <summary>Returns the total count of objects.</summary>
        Int64 GetCount();

        /// <summary>Finds a <see cref="DATA_DICTIONARY"/> instance by the primary key value.</summary>
        DATA_DICTIONARY Find(string dICTIONARY_ID);

        /// <summary>Finds all DATA_DICTIONARY instances.</summary>
        IList<DATA_DICTIONARY> FindAll();

        /// <summary>Inserts a new DATA_DICTIONARY instance into underlying database table.</summary>
        Int64 Insert(DATA_DICTIONARY obj);

        /// <summary>Update the underlying database record of a DATA_DICTIONARY instance.</summary>
        Int64 Update(DATA_DICTIONARY obj);

        /// <summary>Delete the underlying database record of a DATA_DICTIONARY instance.</summary>
        Int64 Delete(DATA_DICTIONARY obj);
    }
}
