// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using ConsoleApp1;
using System;
using System.Transactions;

public enum userType
{
    Admin, 
    Doctor, 
    Patient, 
    LoggedOut
}

namespace TestProgram
{
    public class Program
    {

        //private bool LoggedIn;
        /*public userType currentUserType = userType.LoggedOut;*/
        static void Main(string[] args) 
        {
            /*Console.WriteLine("Hello World");

            //StartProgram();

            Admin admin1 = new Admin(1, "Ryan");
            admin1.MainMenu();

            Doctor doctor1 = new Doctor(01, "Pan");
            doctor1.MainMenu();

            Patient patient1 = new Patient(001, "Li");
            patient1.MainMenu();

            TextMenu textMenu = new TextMenu();
            textMenu.PrintLogInMenu();*/

            //StartProgram();

            TextMenu textMenu = new TextMenu();
            textMenu.PrintLogInMenu(); 

            Console.ReadKey();
        }

        public void StartProgram()
        {
            //Console.WriteLine("This will be the login interface");
            TextMenu textMenu = new TextMenu();
            textMenu.PrintLogInMenu();
        }
    }

    public class TextMenu
    {

        public userType currentUserType = userType.LoggedOut;

        public string LogInID;
        public string LogInPW;

        private String correctAdminID = "00001";
        private String correctAdminPW = "12345678";

        private String correctDoctorID = "10001";
        private String correctDoctorPW = "123456";

        private String correctPatientID = "11001";
        private String correctPatientPW = "11223344";

        private bool LoggedIn;
        public void PrintLogInMenu()
        {
            
            do
            {
                Console.WriteLine("Welcome to DOTNET Hospital Management System");
                Console.Write("ID: ");
                //String LogInID = Console.ReadLine();
                LogInID = Console.ReadLine();
                Console.Write("Password: ");
                //String LogInPW = Console.ReadLine();
                LogInPW = Console.ReadLine();

                TestLogInCredentials(LogInID, LogInPW);
            }
            while (!LoggedIn); 

            switch (currentUserType)
            {
                case userType.LoggedOut:
                    Console.WriteLine("The system is still at LoggedOut state");
                    Console.ReadKey();
                    break;
                case userType.Admin:
                    //Console.WriteLine("The system is now at Admin state");
                    //Console.ReadKey();

                    Admin admin = new Admin(LogInID, LogInPW);
                    admin.MainMenu();

                    LoggedIn = true;
                    currentUserType = userType.LoggedOut;

                    break;
                case userType.Doctor:
                    Console.WriteLine("The system is now at Doctor state");
                    Console.ReadKey();
                    break;
                case userType.Patient:
                    Console.WriteLine("The system is now at Patient state");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Here is the Default state ;p");
                    Console.ReadKey();
                    break;
            }

        }

        public void TestLogInCredentials(String LogInID, String LogInPW)
        {
            if (LogInID == null && LogInPW == null) 
            {
                Console.WriteLine("Empty Log In Credentials! \nPress any keys to retry");
                Console.ReadKey();
                Console.Clear();
                return;
                //
            }
            else if (LogInID != correctAdminID && LogInID != correctDoctorID && LogInID != correctPatientID)
            {
                Console.WriteLine("Incorrect Log In ID! \nPress any keys to retry");
                Console.ReadKey();
                Console.Clear();
                return;
                //Console.ReadKey();
            }
            /*else if (LogInPW != correctAdminID && LogInPW != correctDoctorID && LogInPW != correctPatientID)
            {
                Console.WriteLine("Incorrect Log In Password! \nPress any keys to retry");
                Console.ReadKey();
                Console.Clear();
                return;
                //Console.ReadKey();
            }*/

            if (LogInID == correctAdminID && LogInPW == correctAdminPW)
            {
                //Console.WriteLine("You now have successfully logged in as: ADMIN \nPress any keys to continue. ");
                currentUserType = userType.Admin;
                LoggedIn = !LoggedIn;
                //Console.ReadKey();
                Console.Clear();
                return;
            }

            if (LogInID == correctDoctorID && LogInPW == correctDoctorPW)
            {
                Console.WriteLine("You now have successfully logged in as: DOCTOR \nPress any keys to continue. ");
                currentUserType = userType.Doctor;
                LoggedIn = !LoggedIn;
                Console.ReadKey();
                Console.Clear();
                return;
            }

            if (LogInID == correctPatientID && LogInPW == correctPatientPW)
            {
                Console.WriteLine("You now have successfully logged in as: PATIENT \nPress any keys to continue. ");
                currentUserType = userType.Patient;
                LoggedIn = !LoggedIn;
                Console.ReadKey();
                Console.Clear();
                return;
            }

            //LoggedIn = !LoggedIn; // This should set LoggedIn to true at all times. 
            Console.WriteLine("Wrong Password! \nPress any keys to retry. ");

            Console.ReadKey();
            Console.Clear();

            //FileManager.ReadFromFile(LogInID);
        }
    }
        
}