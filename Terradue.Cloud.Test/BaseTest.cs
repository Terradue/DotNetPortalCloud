using System;
using NUnit.Framework;
using System.IO;
using Terradue.Portal;
using System.Text.RegularExpressions;

namespace Terradue.Test {
    public class BaseTest : AdminTool {

        protected IfyContext context;
        private string connectionString;

        protected string DatabaseName { get; set; }
        protected string BaseDirectory { get; set; }

        public string GetConnectionString() {
            string result = "Server=localhost; Port=3306; User Id=root; Database=TerradueCloudTest";
            bool replaceDatabaseName = (DatabaseName != null);
            Match match = Regex.Match(result, "Database=([^;]+)");
            if (replaceDatabaseName) {
                if (match.Success) result = result.Replace(match.Value, "Database=" + DatabaseName);
                else result += "; Database=" + DatabaseName;
            } else {
                if (match.Success) DatabaseName = match.Groups[1].Value;
                else throw new Exception("No database name specified");
            }
            return result;
        }

        [TestFixtureSetUp]
        public virtual void FixtureSetup() {
            connectionString = GetConnectionString();
            if (BaseDirectory == null) BaseDirectory = Directory.GetCurrentDirectory() + "/../database";

            AdminTool adminTool = new AdminTool(DataDefinitionMode.Create, BaseDirectory, null, connectionString);

            try {
                adminTool.Process();
                context = IfyContext.GetLocalContext(connectionString, false);
                context.Open();
                context.LoadConfiguration();
            } catch (Exception e) {
                Console.Error.WriteLine(e.Message);
                throw;
            }
        }

        [TestFixtureTearDown]
        public virtual void FixtureTearDown() {

            //context.Execute(String.Format("DROP DATABASE {0};", DatabaseName));
            context.Close();
        }
    }
}

