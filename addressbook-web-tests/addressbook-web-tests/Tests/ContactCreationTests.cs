using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        

        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.GoToHomepage();
            app.Auth.Login(new AccountData("admin","secret"));
            app.Contacts.InitContactCreation();
            ContactData contact = new ContactData("John", "Doe");
            contact.NickName = "Yappie";
            contact.Birthday = new ContactData.DataInfo(2, 5, 1999);
            app.Contacts.FillContactInfo(contact);
            app.Contacts.SubminContactInfo();
            app.Auth.Logout();
        }

        

        
    }
}
