// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using ConsoleApp1;
using System;

namespace TestProgram
{
    public class Program
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("Hello World");

            //StartProgram();

            Admin admin = new Admin(001);
            admin.MainMenu();

            Console.ReadKey();
        }

        public void StartProgram()
        {
            Console.WriteLine("This will be the login interface");
        }
    }

    public abstract class Person
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        //public string Description { get; set; }
        public Person(string personName)
        {   
            this.Name = personName;
        }

        //public virtual void DisplayMainMenu();

    }

    public class Patient: Person
    {
        private int Patient_ID;

        public Patient(int patient_ID): base(Name)
        {
            this.Patient_ID = patient_ID;
        }

        public void MainMenu()
        {
            Console.WriteLine("This would display the main menu for the patient");
        }
    }

    public class Doctor: Person
    {
        private int Doctor_ID;

        public Doctor(int doctor_ID)// : base(Name)
        {
            this.Doctor_ID = doctor_ID;
        }

        public void MainMenu()
        {
            Console.WriteLine("This would display the main menu for the doctor");
        }
    }
}