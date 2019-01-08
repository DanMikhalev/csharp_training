using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstName;
        private string lastName;
        private string middleName ="";
        private string nickName = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string home = "";
        private string mobile = "";
        private string work = "";
        private string fax = "";
        private string email = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private DataInfo birthday =  new DataInfo();
        private string address2 = "";
        private string phone2 = "";
        private string notes = "";
        private DataInfo additionalDate = new DataInfo();

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return middleName;
            }

            set
            {
                middleName = value;
            }
        }

        public string NickName
        {
            get
            {
                return nickName;
            }

            set
            {
                nickName = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Company
        {
            get
            {
                return company;
            }

            set
            {
                company = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string Home
        {
            get
            {
                return home;
            }

            set
            {
                home = value;
            }
        }

        public string Mobile
        {
            get
            {
                return mobile;
            }

            set
            {
                mobile = value;
            }
        }

        public string Work
        {
            get
            {
                return work;
            }

            set
            {
                work = value;
            }
        }

        public string Fax
        {
            get
            {
                return fax;
            }

            set
            {
                fax = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Email2
        {
            get
            {
                return email2;
            }

            set
            {
                email2 = value;
            }
        }

        public string Email3
        {
            get
            {
                return email3;
            }

            set
            {
                email3 = value;
            }
        }

        public string Homepage
        {
            get
            {
                return homepage;
            }

            set
            {
                homepage = value;
            }
        }

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
        public string Address2
        {
            get
            {
                return address2;
            }

            set
            {
                address2 = value;
            }
        }

        public string Phone2
        {
            get
            {
                return phone2;
            }

            set
            {
                phone2 = value;
            }
        }

        public string Notes
        {
            get
            {
                return notes;
            }

            set
            {
                notes = value;
            }
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
            firstName = "John";
            middleName = "Unknown";
            lastName = "Doe";
            Birthday = new DataInfo();
        }
        public ContactData(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
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
    }
}
