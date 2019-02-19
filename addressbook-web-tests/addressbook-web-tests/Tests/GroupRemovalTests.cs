using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {


        [Test]
        public void GroupRemovalTest()
        {
            if (app.Groups.GetGroupsCount() < 1)
            {
                app.Groups.Create(new GroupData("theta"));
            }
            List<GroupData> oldGroups = GroupData.GetAll();

            GroupData groupToBeRemoved = oldGroups[0];
            app.Groups.Remove(groupToBeRemoved);

            Assert.AreEqual(app.Groups.GetGroupsCount(), oldGroups.Count - 1);

            List<GroupData> newGroups = GroupData.GetAll();
            if (oldGroups.Count > 0) oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, groupToBeRemoved.Id);
            }
        }


    }
}
