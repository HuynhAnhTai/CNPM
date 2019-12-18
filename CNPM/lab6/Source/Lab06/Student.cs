using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06
{
    public class Student
    {
        public Student(string name, DateTime birth, bool isMale, string mail)
        {
            Name = name;
            Birth = birth;
            this.isMale = isMale;
            Mail = mail;
        }

        public Student(int iD, string name, DateTime birth, bool isMale, string mail)
        {
            ID = iD;
            Name = name;
            Birth = birth;
            this.isMale = isMale;
            Mail = mail;
        }

        public int ID { get; set; }

        public String Name { get; set; }

        public DateTime Birth { get; set; }

        public bool isMale { get; set; }

        public String Mail { get; set; }
    }
}
