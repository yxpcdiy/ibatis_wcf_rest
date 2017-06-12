using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WcfServiceRest
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            EnableCrossDomainAjaxCall();

            
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                //if (HttpContext.Current.Request.Headers["certificateId"] != null)
                //{
                //    string headerCert = HttpContext.Current.Request.Headers["certificateId"].ToString();
                //}
                //else
                //{
                //    throw new Exception("非法的请求服务");
                //}
            }
            catch(Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        //启用跨域访问
        private void EnableCrossDomainAjaxCall()
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");

            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT,DELETE");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Origin, X-Requested-With,Content-Type, Accept,certificateId");//certificateId自定义头信息
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }
        }

        private void RegisterRoutes()
        {
            WebServiceHostFactory factory = new WebServiceHostFactory();
            //RouteTable.Routes.Add(new ServiceRoute("ServicePost", factory, typeof(RestService.ServicePost)));
            RouteTable.Routes.Add(new ServiceRoute("DataDictionaryService", factory, typeof(RestService.DataDictionaryService)));
            RouteTable.Routes.Add(new ServiceRoute("FileUploadService", factory, typeof(RestService.FileUploadService)));
        }
    }
}