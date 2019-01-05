using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Navigator.GoToContactsPage();
            ContactData contact = new ContactData("Roma", "Minaev");
            contact.NickName = "Dorn";
            contact.Birthday = new ContactData.DataInfo(2, 1, 1993);
            app.Contacts.Modify(1,contact);
        }
    }
}
