using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class GroupModificationTests :TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData group = new GroupData("qqq");
            group.Footer = "gve";
            group.Header = "ccc";
            app.Groups.Modify(2, group);
        }
    }
}
