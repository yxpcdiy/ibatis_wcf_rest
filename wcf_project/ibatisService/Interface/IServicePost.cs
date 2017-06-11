using ibatisModel.Entry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ibatisBusiness
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IServicePost”。
    [ServiceContract]
    public interface IServicePost
    {
        /// <summary>
        /// 修改数据字典主类信息
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "*",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        string UpdateDictionaryInfo(DATA_DICTIONARY test);


        //[OperationContract]
        //[WebInvoke(Method = "POST",
        //    UriTemplate = "UpdateDictionaryInfo",
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.Bare)]

        [OperationContract]
        [WebInvoke(Method = "*",
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Bare)]
        int InsertCustomer(string str);

    }

}
