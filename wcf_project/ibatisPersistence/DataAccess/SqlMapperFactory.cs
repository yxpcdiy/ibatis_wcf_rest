using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using IBatisNet.DataMapper.SessionStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ibatisPersistence.DataAccess
{
    public class SqlMapperFactory
    {
        private string _configFileOfDataAccess;
        private ISqlMapper _sqlMapperWriter;
        private ISqlMapper _sqlMapperReader;

        public SqlMapperFactory(string configFileOfDataAccess)
        {
            _configFileOfDataAccess = configFileOfDataAccess;

            try
            {
                DomSqlMapBuilder builderReader = new DomSqlMapBuilder();
                _sqlMapperReader = builderReader.Configure(@"Config\SqlMapReader.config");//_configFileOfDataAccess);
                _sqlMapperReader.SessionStore = new HybridWebThreadSessionStore(_sqlMapperReader.Id);

                DomSqlMapBuilder builderWriter = new DomSqlMapBuilder();
                _sqlMapperWriter = builderWriter.Configure(@"Config\SqlMapWriter.config");
                _sqlMapperWriter.SessionStore = new HybridWebThreadSessionStore(_sqlMapperWriter.Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public ISqlMapper GetSqlWriterDao()
        {
            return _sqlMapperWriter;

        }
        public ISqlMapper GetSqlReaderDao()
        {
            return _sqlMapperReader;
        }

    }
}
