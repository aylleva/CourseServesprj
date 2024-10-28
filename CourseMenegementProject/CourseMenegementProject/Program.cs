using CourseMenegementProject.Services;

namespace CourseMenegementProject
{
    internal class Program
    {
        static void Main(string[] args)
        {

          CourseServis courseservis=new CourseServis();
            string choose;

            do {
                Console.WriteLine("\n1.Create New Group\n2.Show Group List\n3.Changes on Group\n4.Create a Student\n5.Show the  students in Group\n6.Show all Students.\n\n\n0.Exit");
                choose=Console.ReadLine();

                switch (choose) 
                
                {

                    case "1":

                        courseservis.CreateGroup();

                        break;
                    case "2":
                        courseservis.GroupList();
                        break;

                    case "3":
                        courseservis.ChangeGroup();
                        break;
                    case "4":
                        courseservis.AddStudents();
                        break;
                    case "5":
                        courseservis.StudentsList();
                        break;
                    case "6":
                        courseservis.AllStudents();
                        break;
                    default:
                        Console.WriteLine("This Service Does Not Exist!");
                        break;


                }



















            } while (choose!="0");
        }
    }
}