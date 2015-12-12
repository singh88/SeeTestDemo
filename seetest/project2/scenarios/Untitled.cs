using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using experitestClient;

namespace Experitest
{
    [TestClass]
    public class Untitled
    {
        private string host = "localhost";
        private int port = 8889;
        private string projectBaseDirectory = "/Users/xcj600/workspace/project2";
        protected Client client = null;
        
        [TestInitialize()]
        public void SetupTest()
        {
            client = new Client(host, port, true);
            client.SetProjectBaseDirectory(projectBaseDirectory);
            client.SetReporter("xml", "reports", "Untitled");
        }

        [TestMethod]
        public void TestUntitled()
        {
            // it is recommended to start your script with SetDevice command:
            // client.SetDevice( <Device Name>);
            client.Launch("com.experitest.ExperiBank", true, false);
            client.VerifyElementFound("LoginPage", "userName", 0);
            client.VerifyElementFound("LoginPage", "passWord", 0);
            client.VerifyElementFound("LoginPage", "login", 0);
            client.Click("LoginPage", "userName", 0, 1);
            client.SendText("company");
            client.Click("LoginPage", "passWord", 0, 1);
            client.SendText("company");
            client.Click("LoginPage", "login", 0, 1);
        }

        [TestCleanup()]
        public void TearDown()
        {
        // Generates a report of the test case.
        // For more information - https://docs.experitest.com/display/public/SA/Report+Of+Executed+Test
        client.GenerateReport(false);
        // Releases the client so that other clients can approach the agent in the near future. 
        client.ReleaseClient();
        }
    }
}