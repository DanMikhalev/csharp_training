using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData groupModified = new GroupData("eve");
            groupModified.Footer = "gve";
            groupModified.Header = "ccc";


            if (app.Groups.GetGroupsCount() < 1)
            {
                app.Groups.Create(new GroupData("theta"));
            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData groupBeforeModification = oldGroups[0];

            app.Groups.Modify(0, groupModified);


            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupsCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups[0].Name = groupModified.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == groupBeforeModification.Id) Assert.AreEqual(groupModified.Name, group.Name);
            }
        }
    }
}
