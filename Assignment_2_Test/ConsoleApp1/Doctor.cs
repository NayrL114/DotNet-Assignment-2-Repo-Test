using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Doctor: User
    {
        private string Doctor_ID;

        public Doctor(string doctor_ID, string name)// :base(Name)
        {
            this.Doctor_ID = doctor_ID;
            this.Name = name;
        }

        public void MainMenu()
        {
            Console.WriteLine("This would display the main menu for the Doctor");
            Console.WriteLine("The Doctor ID is {0} and the Name is {1}", this.Doctor_ID, this.Name);
        }
    }
}
