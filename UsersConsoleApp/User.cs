using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersConsoleApp 
{
    internal class User : IComparable
    {
         string FirstName;
        public string firstname { 
            get { return this.FirstName; }
            set { this.FirstName = value; } 
        }

        string LastName; 
        public string lastname {
            get { return this.LastName; }
            set { this.LastName = value; }
        }

        string Email;
        public string email {
            get { return this.Email; }
            set { this.Email = value; }
        }

        int BirthYear;
        public int birthyaer {
            get { return this.BirthYear; }
            set { this.BirthYear = value; }
        }

        public User () { }
        public User (string _firtsname , string _lastname , string _email , int _birthyaer)
        {
            this.FirstName = _firtsname;
            this.LastName = _lastname;  
            this.Email = _email;    
            this.BirthYear = _birthyaer;
        }

       public virtual string getDetails ()
        {
            return$"First Name:{this.FirstName}\nLast Name:{this.LastName}\nEmail:{this.Email}\nBirth Year:{this.BirthYear}";
        }

        public int CompareTo (object obj)
        {
            User someUser = (User)obj;
            if (this.BirthYear > someUser.BirthYear) return -1;
            if(this.BirthYear < someUser.BirthYear) return 1;
            return 0;
        }
    }
}
