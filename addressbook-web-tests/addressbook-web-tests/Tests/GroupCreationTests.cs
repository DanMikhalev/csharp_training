using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();

            for (int i = 0; i< 5; i++)
            {
                groups.Add(
                    new GroupData(GenerateRandomString(30))
                    {
                        Header = GenerateRandomString(100),
                        Footer = GenerateRandomString(100)
                    });
            }
            return groups;
        }

        

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTest(GroupData group)
        {
            //GroupData group = new GroupData("aaa");
            //group.Footer = "uu";
            //group.Header = "eee";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        //[Test]
        //public void EmptyGroupCreationTest()
        //{
        //    GroupData group = new GroupData("");
        //    group.Footer = "";
        //    group.Header = "";
        //    List<GroupData> oldGroups = app.Groups.GetGroupList();

        //    app.Groups.Create(group);

        //    Assert.AreEqual(app.Groups.GetGroupsCount(), oldGroups.Count + 1);

        //    List<GroupData> newGroups = app.Groups.GetGroupList();
        //    oldGroups.Add(group);
        //    oldGroups.Sort();
        //    newGroups.Sort();
        //    Assert.AreEqual(oldGroups, newGroups);
        //}

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            group.Footer = "";
            group.Header = "";
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

    }
}
