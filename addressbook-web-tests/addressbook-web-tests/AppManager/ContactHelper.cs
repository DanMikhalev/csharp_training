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

        public ContactData GetContactListFromTable(int index)
        {
            manager.Navigator.GoToContactsPage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;
            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }

        internal ContactData GetContactListFromInfo(int index)
        {
            manager.Navigator.GoToContactsPage();
            GoToDetailedInfo(index);
            string info = driver.FindElement(By.Id("content")).Text;
            return new ContactData() { DetailedInfo = info };
        }

        public ContactData GetContactListFromModificationForm(int index)
        {
            manager.Navigator.GoToContactsPage();
            InitModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
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
                    contactCache.Add(new ContactData(element.FindElements(By.CssSelector("td"))[2].Text, element.FindElements(By.CssSelector("td"))[1].Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("id")
                    });
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

        private ContactHelper GoToDetailedInfo(int index)
        {
            driver.FindElements(By.Name("entry"))[index].
                FindElement(By.TagName("img")).Click();
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
            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.WorkPhone);
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
