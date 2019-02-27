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

            string idRemoved = app.ProjManager.RemoveProject(0);
            oldList.Remove(oldList.First(x => x.Id == idRemoved));
            oldList.Sort();

            List<ProjectData> newList = ProjectData.GetAll();
            newList.Sort();

            Assert.AreEqual(oldList.Count, newList.Count);
            Assert.AreEqual(oldList, newList);

            bool contains = true;
            foreach (ProjectData proj in newList)
            {
                if (oldList.First(x => x.Id == proj.Id) == null) contains = false;
                break;
            }
            Assert.IsTrue(contains);
        }

    }
}
