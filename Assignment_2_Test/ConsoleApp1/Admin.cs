using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class Admin: User
    {
        private string Admin_ID;

        public string MainMenuInputString;
        public int MainMenuInput;

        public bool LoggedIn = true;
        
        public Admin(string admin_ID, string name)// :base(Name)
        {
            this.Admin_ID = admin_ID;
            this.Name = name;
        }

        public void MainMenu()
        {
            

            do
            {

                //Console.WriteLine("This would display the main menu for the ADMIN");
                Console.WriteLine("The Admin ID is {0} and the Name is {1}", this.Admin_ID, this.Name);

                Console.WriteLine("Welcome to DOTNET Hospital Management System, Admin {0}", this.Name);

                Console.WriteLine("Please choose an option: ");
                Console.WriteLine("1. List all doctors");
                Console.WriteLine("2. Check doctor details");
                Console.WriteLine("3. List all patients");
                Console.WriteLine("4. Check patient details");
                Console.WriteLine("5. Add doctor");
                Console.WriteLine("6. Add patient");
                Console.WriteLine("7. Log Out");
                Console.WriteLine("8. Exit");
                Console.WriteLine("\nYour input for choosing option is: ");

                //MainMenuInput = Convert.ToInt32(Console.ReadLine());
                MainMenuInputString = Console.ReadLine();
                //Console.WriteLine("MainMenuInputString is {0}", MainMenuInputString);
                //MainMenuInput = Convert.ToInt32(Console.ReadLine());
                try
                {
                    MainMenuInput = Convert.ToInt32(MainMenuInputString);
                    //Console.WriteLine("MainMenuInput is {0}", MainMenuInput);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("\nInvalid Input format. \nPress any keys to retry");
                    Console.ReadKey();
                    Console.Clear();
                }


                //

                //if () 
                //if (MainMenuInput.GetTypeCode() != TypeCode.Int32) // checking if input is valid
                //{
                switch (MainMenuInput)
                {
                    case 7:
                        Console.WriteLine("\nLogging out, Thank you!\nPress any keys to continue");
                        Console.ReadKey();
                        Console.Clear();
                        LoggedIn = !LoggedIn; // Logging out of admin user and stop admin menu displaying. 
                        return;
                    case 8:
                        Console.WriteLine("\nExiting application, Thank you!\nPress any keys to continue");
                        Console.ReadKey();

                        Environment.Exit(0);

                        //Console.Clear();
                        //LoggedIn = !LoggedIn; // Logging out of admin user and stop admin menu displaying. 
                        return;
                        //break;
                    default:
                        Console.WriteLine("\nIncorrect number Input. \nPress any keys to retry");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }

                /*if (MainMenuInput == 8)
                    {
                        Console.WriteLine("Logging Out, Thank you!\nPress any keys to continue");
                        Console.ReadKey();

                        LoggedIn = !LoggedIn; // Logging out of admin user and stop admin menu displaying. 
                        return;
                    }
                    else
                    {
                        
                    }*/
                /*}
                else
                {
                    Console.WriteLine("Invalid Input. \nPress any keys to retry");
                    Console.ReadKey();
                }*/
            }
            while (LoggedIn);           

            
        }
    }
}
