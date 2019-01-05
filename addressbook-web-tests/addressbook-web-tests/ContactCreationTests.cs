﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        

        [Test]
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin","secret"));
            InitContactCreation();
            ContactData contact = new ContactData("John", "Doe");
            contact.NickName = "Yappie";
            contact.Birthday = new ContactData.DataInfo(2, 5, 1999);
            FillContactInfo(contact);
            SubminContactInfo();
            Logout();
        }

        

        
    }
}
