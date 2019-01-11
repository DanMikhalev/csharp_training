using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {


        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            if (oldGroups.Count < 1) app.Groups.Create(new GroupData("theta"));
            app.Groups.Remove(0);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            if (oldGroups.Count > 0) oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }


    }
}
