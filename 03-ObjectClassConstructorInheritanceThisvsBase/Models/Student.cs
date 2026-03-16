using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ObjectClassConstructorInheritanceThisvsBase.Models
{
    public class Student : Person
    {
        public string StudentNumber;
        public string Faculty;
        public double GPA;
        public int Year;

        public Student(string firstName, string lastName, int age, string email, string id, string studentNumber, string faculty, double gpa, int year)
                       : base(firstName, lastName, age, email, id)
        {
            this.StudentNumber = studentNumber;
            this.Faculty = faculty;
            this.GPA = gpa;
            this.Year = year;
        }

        public void ShowStudentInfo()
        {
            ShowBasicInfo();
            Console.WriteLine("Telebe No: " + StudentNumber + "\nFakulte: " + Faculty + "\nGPA: " + GPA + "\nKurs: " + Year);
        }

        public double CalculateScholarship()
        {
            if (GPA >= 90) return 500;
            if (GPA >= 80) return 350;
            if (GPA >= 70) return 200;
            return 0;
        }
    }
}
