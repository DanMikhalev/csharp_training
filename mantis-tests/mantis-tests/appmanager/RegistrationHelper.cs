﻿using System.Text.RegularExpressions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class RegistrationHelper :UrlNavigationHelper
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }

        internal void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();
            string url = GetConfirmationUrl(account);
            FillPasswordForm(url,account);
            SubmitPasswordForm();
        }

        private void SubmitPasswordForm()
        {
            driver.FindElement(By.TagName("button")).Click();
        }

        private void FillPasswordForm(string url, AccountData account)
        {
            driver.Url = url;            
            driver.FindElement(By.Name("realname")).SendKeys(account.Name);
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
            driver.FindElement(By.Name("password_confirm")).SendKeys(account.Password);
        }

        private string GetConfirmationUrl(AccountData account)
        {
            string message = manager.Mail.GetLastMail(account);
            return Regex.Match(message, @"http://\S*").Value;
        }


        private void SubmitRegistration()
        {
            driver.FindElement(By.XPath(@"//input[@value='Зарегистрироваться']")).Click();
        }

        private void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

    }
}
