using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersConsoleApp
{
    internal class Student : User
    {
        string Grade ;
        public string grade { 
            get {  return this.Grade; } 
            set { this.Grade = value; }
        }

        public Student() { }
        public Student (string _firtsname, string _lastname, string _email, int _birthyaer , string _grade)
        :base (_firtsname , _lastname , _email , _birthyaer)
        {
            this.grade = _grade;
        }

        public override string getDetails()
        {
            return $"{base.getDetails()}\nGrade:{this.grade}";
        }

    }
}
