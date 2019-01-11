using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Navigator.GoToContactsPage();


            if (app.Contacts.GetContactsCount() < 1) app.Contacts.Create(new ContactData("Nick", "Emilson"));
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData contactToBeRemoved = oldContacts[0];
            app.Contacts.RemoveFirst();

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactsCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            if (oldContacts.Count > 0) oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contactToBeRemoved.Id, contact.Id);
            }
        }
    }
}
