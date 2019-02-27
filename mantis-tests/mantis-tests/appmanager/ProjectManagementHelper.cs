using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }

        public void CreateNewProject(ProjectData project)
        {
            InitProjectCreation();
            FillProjectCreationForm(project);
            SubmitProjectCreationForm();
        }

        public string RemoveProject(int index)
        {
            List<ProjectData> projects = GetProjectsListFromTable();
            if (index > projects.Count - 1) return null;
            string resultId = projects[index].Id;
            InitProjectConfiguration(resultId);
            RemoveButtonClick();
            RemoveButtonClick();
            return resultId;
        }

        private void RemoveButtonClick()
        {
            driver.FindElement(By.XPath(@"//input[@value='Удалить проект']")).Click();
        }

        private List<ProjectData> GetProjectsListFromTable()
        {
            return driver.FindElements(By.XPath(@"//a[contains(@href, 'manage_proj_edit_page.php?project_id=')]/../..")).Select(elem => new ProjectData()
            {
                Name = elem.FindElement(By.TagName("a")).Text,
                Description = elem.FindElements(By.TagName("td"))[4].Text,
                Id = Regex.Match(elem.FindElement(By.TagName("a")).GetAttribute("href"), @"\d+$").Value
            }).ToList();
        }

        private void InitProjectConfiguration(string id)
        {
            driver.FindElement(By.XPath($@"//a[contains(@href, 'manage_proj_edit_page.php?project_id={id}')]")).Click();
        }

        private void SubmitProjectCreationForm()
        {
            driver.FindElement(By.XPath(@"//input[@value='Добавить проект']")).Click();
        }

        private void FillProjectCreationForm(ProjectData project)
        {
            driver.FindElement(By.Id("project-name")).SendKeys(project.Name);
            driver.FindElement(By.Id("project-description")).SendKeys(project.Description);
        }

        private void InitProjectCreation()
        {
            driver.FindElement(By.XPath(@"//button[@type='submit']")).Click();
        }


    }
}
