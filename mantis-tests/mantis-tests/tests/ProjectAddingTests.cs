using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectAddingTests:ProjectManagementTests
    {
        

        [Test]
        public void AddProjectTest()
        {
            ProjectData project = new ProjectData()
            {
                Name = "TestProj1", Description = "TestTestTest"
            };

            List<ProjectData> oldProjectsList = ProjectData.GetAll();

            app.ProjManager.CreateNewProject(project);
            oldProjectsList.Add(project);
            oldProjectsList.Sort();

            List<ProjectData> newProjectsList = ProjectData.GetAll();
            newProjectsList.Sort();

            Assert.AreEqual(oldProjectsList.Count, newProjectsList.Count);
            Assert.AreEqual(oldProjectsList, newProjectsList);
            Assert.IsTrue(newProjectsList.Contains(project));
        }

    }
}
