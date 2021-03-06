﻿using ibatisModel.Entry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ibatisBusiness
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IDataService”。
    [ServiceContract]
    public interface IDataService
    {
        /// <summary>
        /// 获取数据字典主类信息
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET",
        UriTemplate = "GetDictionaryMainInfo",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        string GetDictionaryMainInfo();

        /// <summary>
        /// 功能：根据id查询数据字典主类信息
        /// 创建人：李巧莲
        /// 创建时间：2013-6-26
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET",
            UriTemplate = "GetDictioanryInfoById/{id}",
            ResponseFormat = WebMessageFormat.Json,
            //RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        string GetDictionaryInfoById(string id);
        /// <summary>
        /// 修改数据字典主类信息
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "UpdateDictionaryInfo",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        string UpdateDictionaryInfo(DATA_DICTIONARY dictionary);

    }
}
