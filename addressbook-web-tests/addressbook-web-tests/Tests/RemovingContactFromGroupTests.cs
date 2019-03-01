using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class RemovingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void RemovingContactFromGroup()
        {
            List<GroupData> groups = GroupData.GetAll();

            if (groups.Count == 0)
            {
                app.Groups.Create(new GroupData()
                {
                    Name = "test",
                    Footer = "testFt",
                    Header = "testHead"
                });
                groups = GroupData.GetAll();
            }
            GroupData group = groups[0];

            if (ContactData.GetAll().Count == 0)
            {
                ContactData testContact = new ContactData() { FirstName = GenerateRandomString(15), LastName = GenerateRandomString(15) };
                app.Contacts.Create(testContact);
            }
            if (group.GetContacts().Count == 0)
            {
                app.Contacts.AddContactToGroup(ContactData.GetAll().First(), group);
            }
            List<ContactData> oldList = group.GetContacts();
            
            ContactData contact = oldList[0];

            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);

        }
    }
}
