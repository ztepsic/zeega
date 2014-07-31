using AutoMapper;
using NUnit.Framework;

namespace Zeega.Admin.Web.Tests.App_Start {
    [TestFixture]
    public class AutoMapperConfigTests {

        [Test]
        public void TestMappings() {
            AutoMapperConfig.Configure();
            Mapper.AssertConfigurationIsValid();
        }

    }
}
