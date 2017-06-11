using ibatisCommon;
using ibatisModel;
using ibatisModel.Entry;
using ibatisPersistence.Persistence.IDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace ibatisBusiness
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“DataService”。
    [AspNetCompatibilityRequirements(
       RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [JavascriptCallbackBehavior(UrlParameterName = "callbackparam")]
    public class DataService : IDataService
    {
        private IDATA_DICTIONARYDao _dictionaryDao = null;

        //获取数据字典列表信息
        public string GetDictionaryMainInfo()
        {
            BIZ_DATA_DICTIONARY biz_DATA_DICTIONARY = new BIZ_DATA_DICTIONARY();
            return biz_DATA_DICTIONARY.GetDictionaryMainInfo();
        }
        /// <summary>
        /// 功能：根据id查询数据字典主类信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetDictionaryInfoById(string id)
        {
            BIZ_DATA_DICTIONARY biz_DATA_DICTIONARY = new BIZ_DATA_DICTIONARY();
            return biz_DATA_DICTIONARY.GetDictionaryInfoById(id);
        }
        /// <summary>
        /// 功能：修改数据字典类信息
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public string UpdateDictionaryInfo(DATA_DICTIONARY dictionary)
        {
            BIZ_DATA_DICTIONARY biz_DATA_DICTIONARY = new BIZ_DATA_DICTIONARY();
            return biz_DATA_DICTIONARY.UpdateDictionaryInfo(dictionary);
        }
    }
}
 