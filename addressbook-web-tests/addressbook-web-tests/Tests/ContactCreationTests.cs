using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        

        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("John", "Doe");
            contact.NickName = "Yappie";
            contact.Birthday = new ContactData.DataInfo(2, 5, 1999);
            app.Contacts
                .InitContactCreation()
                .FillContactInfo(contact)
                .SubminContactInfo();
        }

        

        
    }
}
