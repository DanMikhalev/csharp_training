using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class LoginHelper:HelperBase
    {
         

        public LoginHelper(ApplicationManager manager):base(manager)
        {
        }
        public void Login(AccountData acc)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(acc)) { return; }
                Logout();
            }
            Type(By.Name("user"), acc.Username);
            Type(By.Name("pass"), acc.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public bool IsLoggedIn(AccountData acc)
        {
            return IsLoggedIn() 
                && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text 
                == "(" + acc.Username + ")";
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public void Logout()
        {
            if (IsElementPresent(By.LinkText("Logout"))) 
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}
