using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactRemovalTests: AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Navigator.GoToContactsPage();
            app.Contacts.Remove(5);
        }
    }
}
