using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ibatisBusiness
{
    public class BIZ_ServiceBase
    {
        protected H GetDao<H>(string serviceName)
        {
            
            return DaoContainer.GetContainer().Resolve<H>(serviceName);
            //return (H)DaoContainer.GetContainer()[serviceName];  
        }
    }
}
