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
            GroupData group = new GroupData("qqq");
            group.Footer = "gve";
            group.Header = "ccc";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            if (oldGroups.Count < 1)
            {
                app.Groups.Create(new GroupData("theta"));
                oldGroups = app.Groups.GetGroupList();
            }

            app.Groups.Modify(0, group);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupsCount());
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = group.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
