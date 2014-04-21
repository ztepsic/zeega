﻿using System.Data.SQLite;
using NHibernate.Bytecode;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NUnit.Framework;
using Zed.NHibernate.Test;
using Zeega.Domain;

namespace Zeega.Infrastructure.Tests.Dal {
    public class SQLiteNHibernateTestFixture : NHibernateTestFixture {

        private const string CONNECTION_STRING = "Data Source=:memory:;Version=3;New=True;";

        static SQLiteNHibernateTestFixture() {
            TestConnectionProvider.CreateConnectionFunc = connString => new SQLiteConnection(connString);
            Configuration.Proxy(p => p.ProxyFactoryFactory<DefaultProxyFactoryFactory>())
                .DataBaseIntegration(db => {
                    db.Dialect<SQLiteDialect>();
                    db.Driver<SQLite20Driver>();
                    db.ConnectionProvider<TestConnectionProvider>();
                    db.ConnectionString = CONNECTION_STRING;
                })
                .SetProperty(Environment.CurrentSessionContextClass, "thread_static")
                .SetProperty("show_sql", "true")
                .AddAssembly(typeof(AppTenant).Assembly);

            var configProperties = Configuration.Properties;
            if (configProperties.ContainsKey(Environment.ConnectionStringName)) {
                configProperties.Remove(Environment.ConnectionStringName);
            }
        }

        [TestFixtureSetUp]
        public void FixtureSetup() { OnFixtureSetup(); }

        [TestFixtureTearDown]
        public void FixtureTearDown() { OnFixtureTeardown(); }

        [SetUp]
        public void Setup() { OnSetup(); }

        [TearDown]
        public void TearDown() { OnTeardown(); }
    }
}
