﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Mapping;

namespace mantis_tests
{
    [Table(Name = "mantis_project_table")]
    public class ProjectData : IComparable<ProjectData>, IEquatable<ProjectData>
    {
        [Column(Name = "name")]
        public string Name { get; set; }
        [Column(Name = "description")]
        public string Description { get; set; }
        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<ProjectData> GetAll()
        {
            using (ProjectDB db = new ProjectDB())
            {
                return (from proj in db.Projects select proj).ToList();
            }
        }

        public override string ToString()
        {
            return Name + " " + Description;
        }

        public int CompareTo(ProjectData other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public bool Equals(ProjectData other)
        {
            return this.Name == other.Name;
        }
    }
}
