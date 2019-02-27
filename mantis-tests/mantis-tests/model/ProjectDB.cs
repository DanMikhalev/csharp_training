using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests 
{
    public class ProjectDB : LinqToDB.Data.DataConnection
    {
        public ProjectDB() : base("DataBaseConnection") { }
        public ITable<ProjectData> Projects { get { return GetTable<ProjectData>(); } }
    }
}
