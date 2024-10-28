using CourseMenegementProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CourseMenegementProject.Models
{
    internal class Group
    {
        public string NO { get; set; }
        public Categories  Category { get; set; }
        public bool IsOnline { get; set; }

        public List<Student> Students = new List<Student>();
        public int Limit => IsOnline ? 15 : 10;
       
       




    }
}