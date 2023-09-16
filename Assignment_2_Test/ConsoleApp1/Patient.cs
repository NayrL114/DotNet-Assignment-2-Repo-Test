using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class Patient: User
    {
        private string Patient_ID;

        public Patient(string patient_ID, string name)
        {
            this.Patient_ID = patient_ID;
            this.Name = name;
        }

        public void MainMenu()
        {
            Console.WriteLine("This would display the main menu for the patient");
            Console.WriteLine("The Patient ID is {0} and the Name is {1}", this.Patient_ID, this.Name);
        }
    }
}

