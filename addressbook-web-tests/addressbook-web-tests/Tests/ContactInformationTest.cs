using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void ContactInformationTest_ModForm_Table()
        {
            app.Navigator.GoToContactsPage();

            ContactData fromForm = app.Contacts.GetContactListFromModificationForm(0);
            ContactData fromTable = app.Contacts.GetContactListFromTable(0);
            Assert.AreEqual(fromForm, fromTable);
            Assert.AreEqual(fromForm.Address, fromTable.Address);
            Assert.AreEqual(fromForm.AllPhones, fromTable.AllPhones);
            Assert.AreEqual(fromForm.AllEmails, fromTable.AllEmails);
        }

        [Test]
        public void ContactInformationTest_ModForm_DetailedInfo()
        {
            app.Navigator.GoToContactsPage();

            ContactData fromForm = app.Contacts.GetContactListFromModificationForm(1);
            ContactData fromInfo = app.Contacts.GetContactListFromInfo(1);
            //Assert.AreEqual(fromForm, fromInfo);
            Assert.AreEqual(fromForm.DetailedInfo, fromInfo.DetailedInfo);
        }
    }
}
