using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Doctor: User
    {
        public string DoctorID {  get; set; }

        public Doctor(string doctor_ID, string name)// :base(Name)
        {
            this.DoctorID = doctor_ID;
            this.Name = name;
        }

        public Doctor(string doctor_ID, string[] doctorDetails)// :base(Name)
        {
            this.DoctorID = doctor_ID;
            this.Name = doctorDetails[0];
        }

        /*public string DoctorID
        {
            get ==> ReturnTypeEncoder
        }*/

        public void MainMenu()
        {
            Console.WriteLine("This would display the main menu for the Doctor");
            Console.WriteLine("The Doctor ID is {0} and the Name is {1}", this.DoctorID, this.Name);
        }
    }
}
