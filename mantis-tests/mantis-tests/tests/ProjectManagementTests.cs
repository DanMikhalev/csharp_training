using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectManagementTests :TestBase
    {
        [TestFixtureSetUp]
        public void LoginAsAdministrator()
        {
            AccountData superUser = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            app.Login.LoginAs(superUser);
            app.Navigation.OpenProjectManagementPanel();
        }
    }
}
