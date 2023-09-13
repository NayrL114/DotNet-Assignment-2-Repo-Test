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

            Admin admin1 = new Admin(1, "Ryan");
            admin1.MainMenu();

            Doctor doctor1 = new Doctor(01, "Pan");
            doctor1.MainMenu();

            Patient patient1 = new Patient(001, "Li");
            patient1.MainMenu();

            TextMenu textMenu = new TextMenu();
            textMenu.PrintLogInMenu();

            Console.ReadKey();
        }

        public void StartProgram()
        {
            Console.WriteLine("This will be the login interface");
        }
    }

    public class TextMenu
    {
        public void PrintLogInMenu()
        {
            Console.WriteLine("This String is from the print log in menu");
            Console.WriteLine(Console.ReadLine());
        }
    }
        
}