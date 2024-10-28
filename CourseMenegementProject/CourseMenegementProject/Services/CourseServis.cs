using CourseMenegementProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CourseMenegementProject.Services
{
    internal class CourseServis
    {
       
       static List<Group> groups = new List<Group>();
       static List<Student> students = new List<Student>();

        public static int Count { get; set; } 
       
      
        
        public  void CreateGroup()
        {
           
            Console.WriteLine("Choose the field:\n1.Programming\n2.Design\n3.System Administration");

            string choose;
            Categories category;
            string no;
            choose = Console.ReadLine();

            switch (choose)

            {
                case "1":
                    Count = 200;
                    category = Categories.Programming;
                    Count++;
                    no=$"P{Count}";
                    Console.WriteLine($"Group:{no}");
                    
                    break;

                case "2":
                    Count= 200;
                    category= Categories.Design;
                    Count++;
                    no = $"D{Count}";
                    Console.WriteLine($"Group:{no}");
                    Count++;
                    break;
                   
                case"3":
                    Count= 200;
                    category= Categories.SystemAdministration;
                    Count++;
                    no = $"S{Count}";
                    Console.WriteLine($"Group:{no}");
                  
                    break;

                 default:
                    Console.WriteLine("Choose the right option");
                    return;
            }
            
                Console.WriteLine("Do you want to study Online? -- Answer Yes or No");
                string isonline = Console.ReadLine().Trim();
                bool isOnline;


                if (isonline == "Yes" )
                {
                    isOnline = true;

                }
                else if (isonline == "No")
                {
                    isOnline = false;
                }
                else
                {
                    Console.WriteLine("Choose the right option!!");
                    return;
                }

                Group NewGroup = new Group { NO = no, IsOnline = isOnline, Category = category };
                groups.Add(NewGroup);
                Console.WriteLine("Accepted to group succesfully");
                return;
            }

        public void GroupList()
        {
            if(groups.Count == 0)
            {
                Console.WriteLine("Please create a group!");
            }
            foreach(Group group in groups)
            {
                Console.WriteLine($"Group No:{group.NO} Category:{group.Category} Student Count:{group.Students.Count} IsOnline:{group.IsOnline}");
            }
        }


        public  void ChangeGroup()
        {
            Console.WriteLine("Please enter your group NO:");
            string Oldno = Console.ReadLine();

            foreach (Group group in groups)
            {
                if (group.NO != Oldno)
                {
                    Console.WriteLine("This group does not exist.Please enter the right NO!");
                    
                }

                if (group.NO == Oldno)
                {
                    Console.WriteLine("Change the group number:");
                    string newNo = Console.ReadLine();


                    if (Char.IsLower(newNo[0]))
                    {
                        Console.WriteLine("Not correct group No");
                        return;
                    }
                    group.NO = newNo;
                    Console.WriteLine("Group name changed succesfully!");
                }

            }


        }

        public void AddStudents()
        {
            Console.WriteLine("Enter your name:");
            string name=Console.ReadLine();
            string _name = name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
            

            if (_name == null )
            {
                Console.WriteLine("The name  can't by empty.Try Again1");
                return;
            }   
            else if (_name.Length < 3)
            {
                Console.WriteLine("The name must involve min 3 letters!");
                return;
            }


            Console.WriteLine("Enter your surname:");
            string surname = Console.ReadLine();
            string _surname = surname.Substring(0, 1).ToUpper() + surname.Substring(1).ToLower();


            if (_surname ==" ")
            {
                Console.WriteLine("The surname can't be empty.Try again!");
            }


            Console.WriteLine("Are you guaranteed? Answer Yes or No!!");
            string type=Console.ReadLine();
            string  _type;

            if (type=="Yes")
            {
               _type= "Guaranteed";
            }
            else if (type == "No")
            {
               _type = "Not Guaranteed";
            }
            else
            {
                Console.WriteLine("Write the correct format!");
                return;
            }

            Console.WriteLine("Enter the Group name:");
            string Groupno=Console.ReadLine();


            foreach (var group in groups)
            {
               
                
                    if (group.NO == Groupno)
                    {
                        
                        if (group.Students.Count <= group.Limit)
                        {
                            var newstudent = new Student { Name = _name, Surname = _surname, GroupNO = group.NO, Type = _type };
                            students.Add(newstudent);
                            group.Students.Add(newstudent);
                            Console.WriteLine("You are  added to group succesfully!");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("No place in group!");
                            return;
                        }
                    }

                
            }

        }
        public void StudentsList()
        {
            Console.WriteLine("Enter the group No:");
            string groupNo = Console.ReadLine();

            foreach(Group group in groups)
            {
                if (group.NO == groupNo)
                {
                    foreach (Student student in group.Students)
                    {
                        Console.WriteLine($"Name:{student.Name} Surname:{student.Surname} Type:{student.Type} ");
                       
                    }
                    return;
                }
                else
                {
                    Console.WriteLine("Enter the correct group Name!");
                    return;
                }

                
                if (group.Students.Count ==0)
                {
                    Console.WriteLine("The group is empty!");
                    return ;
                }

               
            }
             
        }
        public void AllStudents()
        {
            foreach (Group group in groups) {

              
                 foreach (Student student in students)
                 { 
                      Console.WriteLine($"Name:{student.Name} Surname:{student.Surname} GroupNo:{student.GroupNO} IsOnline:{group.IsOnline}");
                    
                 }
                
               return;
                
            }
        }

    }
}
