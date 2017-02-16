using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class NhibernateBase
    {

        public static void Init()
        {
            //数据库配置文件完全地址
            string dbConfigFullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App.config");
            //Hibernate加载数据库配置文件
            NHibernate.Cfg.Configuration nHConfiguration = new NHibernate.Cfg.Configuration().Configure("App.config");
            //获得session工厂
            var sessionFactory = nHConfiguration.BuildSessionFactory();
            using (var session = sessionFactory.OpenSession())
            {
                var customer = new DAO.Model.Person()
                {
                    Id = 5,
                    Name = "卤鸽",
                    Address = "博客园",
                };
                //插入数据
                session.Save(customer);
                session.Flush();
                //get是直接执行sql语句得到实体对象
                var getCustomer = session.Get<DAO.Model.Person>(1);
                getCustomer.Name = "飞鸽";
                session.SaveOrUpdate(getCustomer);
                session.Flush();
                //load主要在是需要调用的时候才进行执行sql语句
                //var loadCustomer = session.Load<Person>("luge");
                //session.Delete(loadCustomer);
                //session.Flush();
// 测试主修该 ，forer变化
            }

        }
    }
}
