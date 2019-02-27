using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    [TestFixture]
    public class AddNewIssueTests : TestBase
    {
        [Test]
        public void AddNewIssue()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            IssueData issue = new IssueData()
            {
                Summary = "some text",
                Description = "some long text",
                Category = "General"
            };
            ProjectData project = new ProjectData()
            {
                Id = "9"
            };
            app.API.CreateNewIssue(account, project,issue);
        }
    }
}
