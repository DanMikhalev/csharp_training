using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }
        public ContactHelper Create(ContactData contact)
        {
            InitContactCreation();
            FillContactInfo(contact);
            SubminContactInfo();
            return this;
        }

        internal ContactHelper Modify(int contactNum, ContactData contact)
        {
            InitModification(contactNum);
            FillContactInfo(contact);
            SubmitUpdateCommand();
            return this;
        }


        public ContactHelper RemoveFirst()
        {
            SelectFirstContact();
            SubmitDeleteCommand();
            AcceptAlert();
            return this;
        }

        private List<ContactData> contactCache = null;
        internal List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToContactsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    contactCache.Add(new ContactData(element.FindElements(By.CssSelector("td"))[2].Text, element.FindElements(By.CssSelector("td"))[1].Text));
                }
            }
            return contactCache;
        }
        public int GetContactsCount()
        {
            manager.Navigator.GoToContactsPage();
            return driver.FindElements(By.Name("entry")).Count;
        }
        private ContactHelper InitModification(int contactNum)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (contactNum + 1) + "]")).Click();
            return this;
        }


        private ContactHelper AcceptAlert()
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            return this;
        }
        private ContactHelper SubmitUpdateCommand()
        {
            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
            contactCache = null;
            manager.Navigator.GoToContactsPage();
            return this;
        }
        private ContactHelper SubmitDeleteCommand()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact(int contactNum)
        {
            driver.FindElement(By.XPath("//input[@id='" + contactNum + "']")).Click();
            return this;
        }

        public ContactHelper SelectFirstContact()
        {
            driver.FindElements(By.Name("entry"))[0].FindElement(By.Name("selected[]")).Click();
            return this;
        }
        public ContactHelper SubminContactInfo()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contactCache = null;
            manager.Navigator.GoToContactsPage();
            return this;
        }

        public ContactHelper FillContactInfo(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("middlename"), contact.MiddleName);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("nickname"), contact.NickName);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            Type(By.Name("byear"), contact.Birthday.Year.ToString());

            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Birthday.Day.ToString());
            //driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Birthday.GetMonthAsString());
            //driver.FindElement(By.Name("byear")).Clear();
            //driver.FindElement(By.Name("byear")).SendKeys(contact.Birthday.Year.ToString());
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.AdditionalDate.Day.ToString());
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.AdditionalDate.GetMonthAsString());
            Type(By.Name("ayear"), contact.AdditionalDate.Year.ToString());
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
    }
}
