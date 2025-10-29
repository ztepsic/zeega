using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using Zed.NHibernate;

namespace Zeega.Infrastructure.Tests.Dal.NHibernate {
    //[TestFixture]
    public class DbSchemaBuilder : SQLiteNHibernateTestFixture {
        //[Test]
        public void Build() {
            	
            var cfg = NHibernateSessionProvider.Configuration;
            var schemaExport = new SchemaExport(cfg);
            schemaExport.Create(true, true);
            schemaExport.Execute(false, true, false, Session.Connection, null);
        }
    }
}
