using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ibatisModel
{
    [DataContract]
    public class JSONObject<T>
    {

        private string _rspCode;
        /// <summary>
        /// 是否成功
        /// </summary>
        [DataMember]
        public String rspCode
        {
            get { return _rspCode; }
            set { _rspCode = value; }
        }

        private T _Result;
        /// <summary>
        /// 业务实体对象
        /// </summary>
        [DataMember]
        public T Result
        {
            get { return _Result; }
            set { _Result = value; }
        }

        private string _rspDesc;
        /// <summary>
        /// 消息
        /// </summary>
        [DataMember]
        public String rspDesc
        {
            get { return _rspDesc; }
            set { _rspDesc = value; }
        }
    }
}
