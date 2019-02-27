using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class LoginHelper : UrlNavigationHelper
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }
        //login: administrator, password: root

        internal void LoginAs(AccountData account)
        {
            OpenMainPage();
            FillLoginFormWithLogin(account);
            PressConfirm();
            FillLoginFormWithPassword(account);
            PressConfirm();
        }

        private void FillLoginFormWithPassword(AccountData superuserAccount)
        {
            driver.FindElement(By.Name("password")).SendKeys(superuserAccount.Password);
        }

        private void FillLoginFormWithLogin(AccountData superuserAccount)
        {
            driver.FindElement(By.Name("username")).SendKeys(superuserAccount.Name);
        }
        private void PressConfirm()
        {
            driver.FindElement(By.XPath(@"//input[@value='Войти']")).Click();
        }
    }
}
