using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ibatisBusiness
{
    /**/
    /// <summary>
    /// 自定义的容器类,初始化容器的时候,初始化dao,
    /// 定义好的持久层的接口和实现类加载
    /// </summary>
    public class DaoContainer
    {
        private static IWindsorContainer _container;
        public DaoContainer() { }
        public static IWindsorContainer GetContainer()
        {
            if (null == _container)
            {
                _container = new WindsorContainer(new XmlInterpreter());
                //_container.AddFacility("auto.transaction", new TransactionFacility());
            }
            return _container;
        }
    }
}
