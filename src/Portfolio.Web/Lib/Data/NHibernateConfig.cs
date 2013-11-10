using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using Portfolio.Common;
using Portfolio.Web.Models.Mapping;

namespace Portfolio.Web.Lib.Data
{
    public class NHibernateConfig
    {
        private static Configuration configuration;
        private static string connectionString = Config.ConnectionString;
        private static readonly object mutex = new object();
        private volatile static ISessionFactory sessionFactory;

        public static string ConnectionString
        {
            get { return connectionString ?? (connectionString = Config.ConnectionString); }
            set { connectionString = value; }
        }

        public static IEnumerable<Type> ExportedTypes
        {
            get
            {
                var exportedTypes = new List<Type>();
                exportedTypes.AddRange(typeof(CategoryMap).Assembly.GetExportedTypes());
                return exportedTypes;
            }
        }

        public static ISessionFactory SessionFactory
        {
            get
            {
                InitializeSessionFactory();
                return sessionFactory;
            }
            set { sessionFactory = value; }
        }

        public ISession GetSession()
        {
            InitializeSessionFactory();            
            return sessionFactory.OpenSession();
        }

        private static void InitializeSessionFactory()
        {
            if (sessionFactory == null)
            {
                lock (mutex)
                {
                    if (sessionFactory == null)
                    {
                        configuration = new Configuration();
                        configuration.DataBaseIntegration(db =>
                        {
                            db.ConnectionString = connectionString;
                            db.Dialect<MsSql2008Dialect>();
                            db.Driver<SqlClientDriver>();
                            db.Timeout = 20;
                        });
                        var modelMapper = new ModelMapper();
                        modelMapper.AddMappings(ExportedTypes);
                        var mappingDocument = modelMapper.CompileMappingForAllExplicitlyAddedEntities();
                        configuration.AddMapping(mappingDocument);
                        sessionFactory = configuration.BuildSessionFactory();
                    }
                }
            }
        }
    }
}
