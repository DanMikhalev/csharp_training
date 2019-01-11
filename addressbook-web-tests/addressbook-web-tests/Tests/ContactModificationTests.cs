using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Navigator.GoToContactsPage();
            ContactData contact = new ContactData("Roma", "Minaev");
            contact.NickName = "Dorn";
            contact.Birthday = new ContactData.DataInfo(2, 1, 1993);

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            if (oldContacts.Count < 1)
            {
                app.Contacts.Create(new ContactData("Nick", "Emilson"));
                oldContacts = app.Contacts.GetContactList();
            }

            app.Contacts.Modify(0, contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].FirstName = contact.FirstName;
            oldContacts[0].LastName = contact.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
