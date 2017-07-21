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
using WcfServiceRest.Interface;
using ibatisBusiness;
using System.IO;

namespace WcfServiceRest.RestService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“DataService”。
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [JavascriptCallbackBehavior(UrlParameterName = "callbackparam")]
    //文件上传服务
    public class FileUploadService : IFileUploadService
    {
        public FileUploadService()
        { }

        public string Upload(Stream file, string encodingName)
        {
            //初始化返回参数//////////////////////////////////////////////
            string result = "";
            UploadFileInfo obj = new UploadFileInfo();
            obj._filefullpath = "";
            obj._filename = "";
            JSONObject<UploadFileInfo> objs = new JSONObject<UploadFileInfo>();
            objs.Result = obj;
            objs.rspCode = "001";
            objs.rspDesc = "上传文件失败";
            /////////////////////////////////////////////////////////////


            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Position = 0;

                var encoding = Encoding.GetEncoding(encodingName);
                var reader = new StreamReader(ms, encoding);
                var headerLength = 0L;

                //读取第一行  
                var firstLine = reader.ReadLine();
                //计算偏移（字符串长度+回车换行2个字符）  
                headerLength += encoding.GetBytes(firstLine).LongLength + 2;

                //读取第二行  
                var secondLine = reader.ReadLine();
                //计算偏移（字符串长度+回车换行2个字符）  
                headerLength += encoding.GetBytes(secondLine).LongLength + 2;
                //解析文件名  
                var fileName = new System.Text.RegularExpressions.Regex("filename=\"(?<fn>.*)\"").Match(secondLine).Groups["fn"].Value;

                //一直读到空行为止  
                while (true)
                {
                    //读取一行  
                    var line = reader.ReadLine();
                    //若到头，则直接返回  
                    if (line == null)
                        break;
                    //若未到头，则计算偏移（字符串长度+回车换行2个字符）  
                    headerLength += encoding.GetBytes(line).LongLength + 2;
                    if (line == "")
                        break;
                }

                //设置偏移，以开始读取文件内容  
                ms.Position = headerLength;
                ////减去末尾的字符串：“ -- ”  
                ms.SetLength(ms.Length - encoding.GetBytes(firstLine).LongLength - 3 * 2);
                
                using (var fileToupload = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "UploadFiles\\" + fileName, FileMode.Create))
                {
                    ms.CopyTo(fileToupload);
                    fileToupload.Close();
                    fileToupload.Dispose();
                }

                obj._filename = fileName;
                obj._filefullpath = @"http://www.wcf.com:8733/UploadFiles/" + fileName;

                objs.Result = obj;
                objs.rspCode = "000";
                objs.rspDesc = "成功";
                
            }
            return JSONHelper.ObjectToJSON(objs);
        }
    }

    public class UploadFileInfo
    {
        string filename = "";
        public string _filename
        {
            get { return filename; }
            set { filename = value; }
        }
        string filefullpath = "";

        public string _filefullpath
        {
            get { return filefullpath; }
            set { filefullpath = value; }
        }
    }

}