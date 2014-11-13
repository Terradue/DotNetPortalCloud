using NUnit.Framework;
using Terradue.Cloud;
using System;
using Terradue.Test;
using Terradue.OpenNebula; 
using System.Xml;

namespace Terradue.Cloud.Test {
    [TestFixture()]
    public class OneCloudApplianceTest : BaseTest {

        [TestFixtureSetUp]
        public new void FixtureSetup(){
            base.FixtureSetup();
            context.BaseUrl = "http://localhost:8080";
        }

        [Test()]
        public void TestCase() {
            OneCloudAppliance app = new OneCloudAppliance(context);
            app.Vm = new VM();
        }
    }
}

