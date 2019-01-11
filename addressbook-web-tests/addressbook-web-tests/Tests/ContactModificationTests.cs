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
            ContactData contactModified = new ContactData("Roma", "Minaev");
            contactModified.NickName = "Dorn";
            contactModified.Birthday = new ContactData.DataInfo(2, 1, 1993);


            if (app.Contacts.GetContactsCount() < 1)
            {
                app.Contacts.Create(new ContactData("Nick", "Emilson"));
            }
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData contactBeforeModification = oldContacts[0];
            app.Contacts.Modify(0, contactModified);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].FirstName = contactModified.FirstName;
            oldContacts[0].LastName = contactModified.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == contactBeforeModification.Id) Assert.AreEqual(contactModified, contact);
            }
        }
    }
}
