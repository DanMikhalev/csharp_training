using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private DataInfo birthday = new DataInfo();
        private DataInfo additionalDate = new DataInfo();
        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }
        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }
        [Column(Name = "firstname"), NotNull]
        public string FirstName { get; set; }

        [Column(Name = "lastname"), NotNull]
        public string LastName { get; set; }

        [Column(Name = "middlename"), NotNull]
        public string MiddleName { get; set; }

        [Column(Name = "nickname"), NotNull]
        public string NickName { get; set; }

        [Column(Name = "title"), NotNull]
        public string Title { get; set; }

        [Column(Name = "company"), NotNull]
        public string Company { get; set; }

        [Column(Name = "address"), NotNull]
        public string Address { get; set; }

        [Column(Name = "home"), NotNull]
        public string HomePhone { get; set; }

        [Column(Name = "mobile"), NotNull]
        public string MobilePhone { get; set; }

        [Column(Name = "work"), NotNull]
        public string WorkPhone { get; set; }
        public string AllPhones
        {
            get
            {
                if (string.IsNullOrEmpty(allPhones))
                {
                    allPhones = (Cleanup(HomePhone) + Cleanup(MobilePhone) + Cleanup(WorkPhone)).Trim();
                }
                return allPhones;
            }
            set
            {
                allPhones = value;
            }
        }

        private string Cleanup(string item)
        {
            if (string.IsNullOrEmpty(item)) return "";
            return Regex.Replace(item, "[- ()]", "") + "\r\n";
        }

        private string allPhones;
        [Column(Name = "fax"), NotNull]
        public string Fax { get; set; }

        [Column(Name = "email"), NotNull]
        public string Email { get; set; }

        [Column(Name = "email2"), NotNull]
        public string Email2 { get; set; }

        [Column(Name = "email3"), NotNull]
        public string Email3 { get; set; }
        private string allEmails;
        public string AllEmails
        {
            get
            {
                if (string.IsNullOrEmpty(allEmails))
                {
                    allEmails = (Cleanup(Email) + Cleanup(Email2) + Cleanup(Email3)).Trim();
                }
                return allEmails;
            }
            set
            {
                allEmails = value;
            }
        }
        [Column(Name = "homepage"), NotNull]
        public string Homepage { get; set; }

        internal DataInfo Birthday
        {
            get
            {
                return birthday;
            }

            set
            {
                birthday = value;
            }
        }
        internal DataInfo AdditionalDate
        {
            get
            {
                return additionalDate;
            }

            set
            {
                additionalDate = value;
            }
        }
        [Column(Name = "address2"), NotNull]
        public string Address2 { get; set; }

        [Column(Name = "phone2"), NotNull]
        public string Phone2 { get; set; }

        [Column(Name = "notes"), NotNull]
        public string Notes { get; set; }
        private string detailedInfo;
        public string DetailedInfo
        {
            get
            {
                if (string.IsNullOrEmpty(detailedInfo))
                {
                    detailedInfo =
                        (string.IsNullOrEmpty(FirstName) ? "" : FirstName + " ") +
                        (string.IsNullOrEmpty(MiddleName) ? "" : MiddleName + " ") +
                        (string.IsNullOrEmpty(LastName) ? "" : LastName) +
                         "\r\n" +
                        (string.IsNullOrEmpty(NickName) ? "" : NickName + "\r\n") +
                        (string.IsNullOrEmpty(Title) ? "" : Title + "\r\n") +
                        (string.IsNullOrEmpty(Company) ? "" : Company + "\r\n") +
                        (string.IsNullOrEmpty(Address) ? "" : Address + "\r\n") +
                         "\r\n" +
                        (string.IsNullOrEmpty(HomePhone) ? "" : "H: " + HomePhone + "\r\n") +
                        (string.IsNullOrEmpty(MobilePhone) ? "" : "M: " + MobilePhone + "\r\n") +
                        (string.IsNullOrEmpty(WorkPhone) ? "" : "W: " + WorkPhone + "\r\n") +
                        (string.IsNullOrEmpty(Fax) ? "" : "F: " + Fax + "\r\n") +
                         "\r\n" +
                        AllEmails;
                }
                return detailedInfo;
            }
            set { detailedInfo = value; }
        }

        public class DataInfo
        {
            private int day;
            private int month;
            private int year;
            public DataInfo(int day, int month, int year)
            {
                this.day = day;
                this.month = (month > 0 && month < 13) ? month : 1;
                this.year = year;
            }
            public DataInfo()
            {
                day = 1;
                month = 1;
                year = 2018;
            }
            public int Day
            {
                get
                {
                    return day;
                }

                set
                {
                    day = value;
                }
            }

            public int Month
            {
                get
                {
                    return month;
                }

                private set
                {
                    month = value;
                }
            }
            public string GetMonthAsString()
            {
                return (month <= 12 && month >= 1) ? months[month - 1] : "None";
            }
            public int Year
            {
                get
                {
                    return year;
                }

                set
                {
                    year = value;
                }
            }
            private string[] months = new string[] { "January", "February", "March", "April", "May", "June", "Jule", "August", "September", "October", "November", "December" };
        }

        public ContactData()
        {
            FirstName = ""; LastName = "";
            Birthday = new DataInfo();
        }
        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            this.Birthday = new DataInfo();
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(this, other)) return true;
            return FirstName == other.FirstName && LastName == other.LastName;
        }
        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode();
        }

        public override string ToString()
        {
            return "FirstName= " + FirstName + " LastName= " + LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null)) return 1;
            if (FirstName.CompareTo(other.FirstName) == 0) return LastName.CompareTo(other.LastName);
            return FirstName.CompareTo(other.FirstName);
        }
        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }
    }
}
