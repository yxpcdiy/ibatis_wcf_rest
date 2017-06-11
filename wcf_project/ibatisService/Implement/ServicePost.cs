using ibatisCommon;
using ibatisModel;
using ibatisModel.Entry;
using ibatisPersistence.Persistence.IDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace ibatisBusiness
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“ServicePost”。
    //声明允许ajax访问
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [JavascriptCallbackBehavior(UrlParameterName = "callbackparam")]
    public class ServicePost : IServicePost
    {
        private IDATA_DICTIONARYDao _dictionaryDao = null;

        /// <summary>
        /// 功能：修改数据字典类信息
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public string UpdateDictionaryInfo(DATA_DICTIONARY test)
        {
            JSONObject<DATA_DICTIONARY> objs = new JSONObject<DATA_DICTIONARY>();
            objs.rspCode = "000";
            objs.rspDesc = "成功";
            string result = JSONHelper.ObjectToJSON(objs);
            return result;
        }

        public int InsertCustomer(string str)
        {
            return 1;
        }
    }
}
 