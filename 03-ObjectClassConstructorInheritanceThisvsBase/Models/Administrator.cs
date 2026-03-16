using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ObjectClassConstructorInheritanceThisvsBase.Models
{
    public class Administrator : Person
    {
        public string Position;
        public string Department;
        public int AccessLevel;

        public Administrator(string firstName, string lastName, int age, string email, string id, string position, string department, int accessLevel)
                             : base(firstName, lastName, age, email, id)
        {
            this.Position = position;
            this.Department = department;
            this.AccessLevel = accessLevel;
        }

        public void ShowAdminInfo()
        {
            ShowBasicInfo();
            Console.WriteLine("Vezife: " + Position + "\nŞobe: " + Department + "\nGiris Seviyyesi: " + AccessLevel);
        }

        public void GrantAccess(Student student)
        {
            Console.WriteLine("\nAdministrator " + GetFullName() + " telebe " + student.GetFullName() + " ucun giris icazesi verdi.");
        }
    }
}
