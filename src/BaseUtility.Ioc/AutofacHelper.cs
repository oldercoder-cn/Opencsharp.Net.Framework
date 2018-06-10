using Autofac;
using Autofac.Configuration;
using Autofac.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;

namespace BaseUtility.Ioc
{
    public class AutofacHelper
    {
        static IContainer container;
        public static void RegisterDBInstance()
        {
            //https://www.cnblogs.com/liping13599168/archive/2011/07/17/2108734.html
            //http://www.cnblogs.com/caoyc/p/6370650.html
            //http://docs.autofac.org/en/latest/configuration/xml.html#quick-start
            var config = new ConfigurationBuilder();
            string path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"Configs\autofac.xml");
            //config.AddJsonFile(path);//Microsoft.Extensions.Configuration.json.dll
            config.AddXmlFile(path);//Microsoft.Extensions.Configuration.xml.dll

            // Register the ConfigurationModule with Autofac.
            var module = new ConfigurationModule(config.Build());
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);
            container = builder.Build();
        }

        /// <summary>
        /// 获取对象实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceName">数据库类型</param>
        /// <param name="param">数据库连接串等参数</param>
        /// <returns></returns>
        public static T GetDbInstance<T>(string serviceName, params Parameter[] param)
        {
            if (container != null)
            {
                var serviceList = container.Resolve<IEnumerable<T>>(param);//http://www.bkjia.com/Asp_Netjc/1315802.html
                foreach (var service in serviceList)
                {
                    if (service.ToString().ToLower().Equals(serviceName.ToLower()))
                    {
                        return service;
                    }
                }
            }
            return default(T);
        }
    }
}
