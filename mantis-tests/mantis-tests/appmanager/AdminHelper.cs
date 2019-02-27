using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class AdminHelper :LoginHelper
    {
        private string baseUrl;

        public AdminHelper(ApplicationManager manager, string baseUrl) : base(manager) { this.baseUrl = baseUrl; }

        public List<AccountData> GetAllAccounts()
        {
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseUrl + "/manage_user_page.php";
            return driver.FindElements(By.XPath(@"//a[contains(@href, 'manage_user_edit_page.php?user_id=')]/../..")).Select(elem => new AccountData()
            {
                Name = elem.FindElement(By.TagName("a")).Text,
                Id = Regex.Match(elem.FindElement(By.TagName("a")).GetAttribute("href"), @"\d+$").Value,
                Email = elem.FindElements(By.TagName("td"))[2].Text
            }).ToList();
        }

        public void DeleteAccount(AccountData account)
        {
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseUrl + "/manage_user_edit_page.php?user_id="+ account.Id;
            driver.FindElements(By.TagName("input"))[15].Click();
            driver.FindElements(By.TagName("input"))[4].Click();
        }

        private IWebDriver OpenAppAndLogin()
        {
            IWebDriver driver = new SimpleBrowserDriver();
            driver.Url = baseUrl + "/login_page.php";
            if (driver.FindElements(By.XPath(@"//a[contains(@href,'logout')]")).Count > 0)
                driver.FindElement(By.XPath(@"//a[contains(@href,'logout')]")).Click();
            driver.FindElement(By.Id("username")).SendKeys("administrator");
            driver.FindElements(By.TagName("input"))[2].Click();
            //driver.FindElement(By.XPath(@"//input[@value='Войти']")).Click();
            driver.FindElement(By.Id("password")).SendKeys("root");
            driver.FindElements(By.TagName("input"))[5].Click();
            return driver;
        }
    }
}
