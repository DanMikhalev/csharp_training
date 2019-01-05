using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.GoToContactsPage();
            ContactData contact = new ContactData("Doge", "Sparta");
            contact.NickName = "Impaled";
            contact.Birthday = new ContactData.DataInfo(2, 5, 1999);
            app.Contacts.Create(contact);
        }             
    }
}
