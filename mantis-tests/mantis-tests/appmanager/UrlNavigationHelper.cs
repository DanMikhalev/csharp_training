using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class UrlNavigationHelper : HelperBase
    {
        public UrlNavigationHelper(ApplicationManager manager) : base(manager) { }

        public void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.19.0/login_page.php";
        }
        public void OpenRegistrationForm()
        {
            driver.FindElement(By.CssSelector("a.back-to-login-link")).Click();
        }
        public void OpenPage(string url)
        {
            manager.Driver.Url = url;
        }

        public void OpenManagementPanel()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.19.0/manage_overview_page.php";
        }

        public void OpenProjectManagementPanel()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.19.0/manage_proj_page.php";
        }
    }
}
