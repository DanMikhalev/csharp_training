using System;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    public class GroupHelper:HelperBase
    {
        private static string DELETEGROUP_WINTITLE = "Delete group";
        private static string GROUPWINTITLE = "Group editor";

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            OpenGroupsDialog();
            string count = Aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetItemCount", "#0", "");
            for (int i = 0; i< int.Parse(count); i++)
            {

            string item = Aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetText", "#0|#"+i,"");
                groups.Add(new GroupData() { Name = item });
            }
            CloseGroupDialog();
            return groups;
        }

        internal void RemoveAt(int groupNumber)
        {
            OpenGroupsDialog();
            Aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "Select", "#0|#"+groupNumber, "");
            Aux.ControlClick(GROUPWINTITLE,"", "WindowsForms10.BUTTON.app.0.2c908d51");
            Aux.WinWait(DELETEGROUP_WINTITLE);
            Aux.ControlClick(DELETEGROUP_WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            Aux.ControlClick(DELETEGROUP_WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            Aux.ControlClick(DELETEGROUP_WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            Aux.WinWait(GROUPWINTITLE);
            CloseGroupDialog();
        }

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialog();
            Aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            Aux.Send(newGroup.Name);
            Aux.Send("{ENTER}");
            CloseGroupDialog();
        }

        private void CloseGroupDialog()
        {
            Aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        private void OpenGroupsDialog()
        {
            Aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            Aux.WinWait(GROUPWINTITLE);
        }
    }
}