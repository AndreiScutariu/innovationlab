using Api.Notifications.Dal.Convensions;
using Api.Notifications.Models;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Api.Notifications.Repository

{
    public class NhibernateConfig
    {
        private const string ConnectionString = @"Data Source=innovationlab.database.windows.net;User ID=innovationlab;Password=endava123!";

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
                    .AddFromAssemblyOf<Event>()
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