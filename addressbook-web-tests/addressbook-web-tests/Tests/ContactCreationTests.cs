using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.GoToContactsPage();
            ContactData contact = new ContactData("Albert", "Rust")
            {
                NickName = "Rustie",
                Birthday = new ContactData.DataInfo(2, 5, 1999),
                Address = "Fruhlingstrasse, 7",
                Email = "123@123.123", Email2 = "456@456.qwe", Email3 = "123@qwe.asd",
                HomePhone = "+7(342)423-43-12", WorkPhone = "+7(963)623-75-32", MobilePhone = "8 (351) 846 - 214 - 3"
            };
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count +1, app.Contacts.GetContactsCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }             
    }
}
