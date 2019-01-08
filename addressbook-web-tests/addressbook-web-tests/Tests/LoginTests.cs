using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public  class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            //Prepare
            app.Auth.Logout();

            //Action
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);

            //Verification
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            //Prepare
            app.Auth.Logout();

            //Action
            AccountData account = new AccountData("admin", "asdf");
            app.Auth.Login(account);

            //Verification
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }
    }
}
