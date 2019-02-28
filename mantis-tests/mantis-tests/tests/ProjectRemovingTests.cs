using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovingTests : ProjectManagementTests
    {
        [Test]
        public void ProjectRemovingTest()
        {
            List<ProjectData> oldList = ProjectData.GetAll();

            AccountData account = new AccountData() { Name = "administrator", Password = "root" };

            if (oldList.Count < 1)
            {
                Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
                Mantis.ProjectData tempProj = new Mantis.ProjectData() { name = "TestProjectTemp" };
                client.mc_project_add("administrator", "root", tempProj);
                oldList = ProjectData.GetAll();
            }

            app.ProjManager.Remove(account, oldList[0]);

            oldList.RemoveAt(0);
            oldList.Sort();

            List<ProjectData> newList = ProjectData.GetAll();
            newList.Sort();

            Assert.AreEqual(oldList.Count, newList.Count);
            Assert.AreEqual(oldList, newList);

            bool contains = true;
            foreach (ProjectData proj in newList)
            {
                if (oldList.First(x => x.Id == proj.Id) == null)
                {
                    contains = false;
                    break;
                }
            }
            Assert.IsTrue(contains);
        }

    }
}
