using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData()
            {
                summary = issueData.Summary,
                description = issueData.Description,
                category = issueData.Category,
                project = new Mantis.ObjectRef() { id = project.Id }
            };
            //var sdf = client.mc_enum_access_levels(account.Name, account.Password);
            //var projdata = client.mc_projects_get_user_accessible(account.Name, account.Password);
            string version = client.mc_version();
            System.Console.Out.WriteLine(version);
            client.mc_issue_add(account.Name, account.Password, issue);
        }
    }
}
