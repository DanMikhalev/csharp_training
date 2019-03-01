using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            List<GroupData> groups = GroupData.GetAll();
            if (groups.Count == 0)
            {
                app.Groups.Create(new GroupData()
                {
                    Name = "testRemContFromGroup",
                    Footer = "test",
                    Header = "test"
                });
                groups = GroupData.GetAll();
            }
            GroupData group = groups[0];

            List<ContactData> oldList = group.GetContacts();

            ContactData contact;
            if (oldList.Count == 0 || ContactData.GetAll().Except(oldList).Count() == 0)
            {
                contact = new ContactData() { FirstName = GenerateRandomString(25), LastName = GenerateRandomString(10) };
                app.Contacts.Create(contact);
            }

            contact = ContactData.GetAll().Except(oldList).First();

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);

        }
    }
}
