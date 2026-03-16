using _03_ObjectClassConstructorInheritanceThisvsBase.Models;

namespace _03_ObjectClassConstructorInheritanceThisvsBase
{
    class Program
    {
        static void Main()
        {
            Student student1 = new Student("Ali", "Mammadov", 20, "ali@uni.edu.az", "S001", "ST-101", "IT", 88.5, 2);
            Student student2 = new Student("Aysel", "Guliyeva", 19, "aysel@uni.edu.az", "S002", "ST-102", "Economics", 92.0, 1);
            Student student3 = new Student("Rauf", "Hasanov", 21, "rauf@uni.edu.az", "S003", "ST-103", "Law", 68.5, 3);

            Teacher teacher1 = new Teacher("Kamil", "Valiyev", 45, "kamil@uni.edu.az", "T001", "Math", "Algebra", 800, 15);
            Teacher teacher2 = new Teacher("Leyla", "Aliyeva", 35, "leyla@uni.edu.az", "T002", "Languages", "English", 800, 8);

            Administrator admin1 = new Administrator("Fuad", "Nazarov", 50, "fuad@uni.edu.az", "A001", "Dekan", "Education", 5);

            Console.WriteLine("--- TELEBE MELUMATLARI ---");
            student1.ShowStudentInfo(); Console.WriteLine("Teaqud: " + student1.CalculateScholarship() + " AZN\n");
            student2.ShowStudentInfo(); Console.WriteLine("Teaqud: " + student2.CalculateScholarship() + " AZN\n");
            student3.ShowStudentInfo(); Console.WriteLine("Teaqud: " + student3.CalculateScholarship() + " AZN\n");

            Console.WriteLine("--- MUELLIM MELUMATLARI ---");
            teacher1.ShowTeacherInfo(); Console.WriteLine("Maas: " + teacher1.CalculateSalary() + " AZN\n");
            teacher2.ShowTeacherInfo(); Console.WriteLine("Maas: " + teacher2.CalculateSalary() + " AZN\n");

            Console.WriteLine("--- ADMINISTRATOR ---");
            admin1.ShowAdminInfo();
            admin1.GrantAccess(student2);

            double totalScholarship = student1.CalculateScholarship() + student2.CalculateScholarship() + student3.CalculateScholarship();
            decimal totalSalary = teacher1.CalculateSalary() + teacher2.CalculateSalary();

            Console.WriteLine("\n--- STATISTIKA ---");
            Console.WriteLine("Umumi teqaud xerci: " + totalScholarship + " AZN");
            Console.WriteLine("Umumi maas xerci: " + totalSalary + " AZN");
        }
    }
}
