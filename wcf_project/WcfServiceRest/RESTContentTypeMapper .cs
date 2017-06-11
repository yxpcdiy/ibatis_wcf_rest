using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Channels;
using System.Text;

namespace WcfServiceRest
{
     
    public class RESTContentTypeMapper : WebContentTypeMapper
    {
        public override WebContentFormat GetMessageFormatForContentType(string contentType)
        {
            
            if (contentType.IndexOf("json", StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                return WebContentFormat.Json;
            }
            else if (contentType.IndexOf("xml", StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                return WebContentFormat.Xml;
            }
            else
            {
                return WebContentFormat.Json;
            }
        }
    }


}
