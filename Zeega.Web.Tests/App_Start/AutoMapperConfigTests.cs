using AutoMapper;
using NUnit.Framework;
using Zeega.Web.App_Start;

namespace Zeega.Web.Tests.App_Start {
    [TestFixture]
    public class AutoMapperConfigTests {

        [Test]
        public void TestMappings() {
            AutoMapperConfig.Configure();
            Mapper.AssertConfigurationIsValid();
        }

    }
}
