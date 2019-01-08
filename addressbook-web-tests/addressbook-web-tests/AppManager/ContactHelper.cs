﻿using OpenQA.Selenium;
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

        private ContactHelper InitModification(int contactNum)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + contactNum + "]")).Click();
            return this;
        }

        public ContactHelper Remove(int contactNum)
        {
            SelectContact(contactNum);
            SubmitDeleteCommand();
            AcceptDeleting();
            return this;
        }

        private ContactHelper AcceptDeleting()
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            return this;
        }
        private ContactHelper SubmitUpdateCommand()
        {
            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
            return this;
        }
        private ContactHelper SubmitDeleteCommand()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper SelectContact(int contactNum)
        {
            driver.FindElement(By.XPath("//input[@id='" + contactNum + "']")).Click();
            return this;
        }
        public ContactHelper SubminContactInfo()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
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
