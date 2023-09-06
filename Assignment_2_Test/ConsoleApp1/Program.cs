// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;

namespace TestProgram
{
    class Program
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("Hello World");


            Console.ReadKey();
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

    }

    public class Patient: Person
    {
        private int Patient_ID;

        public Patient(int patient_ID): base(Name)
        {
            this.Patient_ID = patient_ID;
        }
    }
}