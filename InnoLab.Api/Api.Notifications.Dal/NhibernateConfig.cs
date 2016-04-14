using Api.Notifications.Dal.Convensions;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Api.Notifications.Dal

{
    public class NhibernateConfig
    {
        private const string ConnectionString = @"Data Source=ssdvm.cloudapp.net\SQLEXPRESS,82;User ID=ssduser;Password=ssduser";

        private static ISession _session;
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();

                return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(ConnectionString))
                .Mappings(m => m.FluentMappings
                    .AddFromAssemblyOf<Base<int>>()
                    .Conventions.Add(new SsdForeignKeyConvention())
                )
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Execute(true, true, false)) //code first
                .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return _session ?? (_session = SessionFactory.OpenSession());
        }
    }
}