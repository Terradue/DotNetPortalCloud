using System;
using NUnit.Framework;
using System.IO;
using Terradue.Portal;

namespace Terradue.Test {
    public class BaseTest : AdminTool {

        protected IfyContext context;
        string connectionString = "Server=localhost; Port=3306; User Id=root; Database=TerradueCloudTest";

        [TestFixtureSetUp]
        public virtual void FixtureSetup() {

            create = true;

            dbMainSchema = "TerradueCloudTest";
            currentSchema = dbMainSchema;
            Verbose = false;
            siteRootDir = "../..";

            try {
                OpenConnection(connectionString);
                schemaExists = true;
            } catch (Exception e) {
                if (!e.Message.Contains("Unknown database"))
                    throw e;
            }

            try {
                CreateSchemas();
            } catch (Exception e) {
                Console.Error.WriteLine(e.Message);
                throw e;
            }

            Site site;
            CoreModule core = new CoreModule(this, "core");
            core.Install();

            CloseConnection();

            try {
                context = IfyContext.GetLocalContext(connectionString, false);
                context.Open();
            } catch (Exception e) {
                Console.Error.WriteLine(e.Message);
                throw e;
            }


        }

        [TestFixtureTearDown]
        public virtual void TestFixtureTearDown() {
            context.Close();
            OpenConnection(connectionString);
            Execute("DROP DATABASE $MAIN$;");
            CloseConnection();
        }
    }
}

