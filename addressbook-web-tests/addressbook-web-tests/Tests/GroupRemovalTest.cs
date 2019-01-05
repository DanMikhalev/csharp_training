using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
       

        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GoToHomepage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.Groups.SelectGroup(2);
            app.Groups.RemoveGroup();
            app.Groups.ReturnToGroupsPage();
            app.Auth.Logout();
        }
        
    
    }
}
