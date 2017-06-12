using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;

namespace WcfServiceRest.Interface
{
    [ServiceContract]
    public interface IFileUploadService
    {


        /// <summary>  
        /// 使用HTML上传文件  
        /// </summary>  
        /// <param name="file">文件流</param>  
        /// <param name="encodingName">HTML的文字编码名</param>  
        [WebInvoke(Method = "POST", UriTemplate = "Upload/{encodingName}")]
        void Upload(Stream file, string encodingName);

    }
}