﻿// See https://aka.ms/new-console-template for more information
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

struct Appointment
{
    Patient bookedPatient;
    Doctor bookedDoctor;
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

        public string LogInID = "";
        public string LogInPW = "";

        //private String[] adminFilelines;
        private List<String> adminFileLines;
        //private String[] doctorFilelines;
        private List<String> doctorFileLines;
        //private String[] patientFilelines;
        private List<String> patientFileLines;
        //private String[] recordedAppointments;
        private List<String> bookedAppointments;

        //private List<Admin> adminList;

        private String[] LoggedInUserDetails;

        /*private String correctAdminID = "00001";
        private String correctAdminPW = "12345678";
        private String adminName = "Ryan";

        private String correctDoctorID = "10001";
        private String correctDoctorPW = "123456";
        private String doctorName = "Susan";

        private String correctPatientID = "11001";
        private String correctPatientPW = "11223344";
        private String patientName = "Pan";*/

        //private String name;

        private bool LoggedIn;
        public void PrintLogInMenu()
        {
            // Below codes will initilise all the lists containing all user details
            /*adminFileLines = FileManager.ReadStringListFromFile("Admins.txt");
            doctorFileLines = FileManager.ReadStringListFromFile("Doctors.txt");
            patientFileLines = FileManager.ReadStringListFromFile("Patients.txt");*/

            //patientFileLines = new List<String>();

            do
            {

                // Below codes will initilise all the lists containing all user details
                adminFileLines = FileManager.ReadStringListFromFile("Admins.txt");
                doctorFileLines = FileManager.ReadStringListFromFile("Doctors.txt");
                patientFileLines = FileManager.ReadStringListFromFile("Patients.txt");

                Console.WriteLine("Welcome to DOTNET Hospital Management System");
                Console.Write("ID: ");
                //String LogInID = Console.ReadLine();
                LogInID = Console.ReadLine();
                Console.Write("Password: ");
                //String LogInPW = Console.ReadLine();
                LogInPW = Console.ReadLine();

                TestLogInCredentials(LogInID, LogInPW);

                switch (currentUserType)
                {
                    case userType.LoggedOut:
                        Console.WriteLine("The system is still at LoggedOut state");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case userType.Admin:
                        //Console.WriteLine("The system is now at Admin state");
                        //Console.ReadKey();

                        //fileTest = FileManager.ReadStringArrayFromFile("test.txt");

                        Admin admin = new Admin(LogInID, LoggedInUserDetails[0]);
                        // CONSIDER UPDATING CONSTRUCTORS TO ACCEPT STRING ARRAY !!!!!!!!!!
                        admin.MainMenu();

                        // Below code executes when user chose log out from admin menu
                        LoggedIn = !LoggedIn;// This should set the log in state to false
                        currentUserType = userType.LoggedOut;
                        LoggedInUserDetails = new string[0];

                        Console.Clear();
                        //PrintLogInMenu();

                        break;
                    case userType.Doctor:
                        /*Console.WriteLine("The system is now at Doctor state");
                        Console.ReadKey();*/

                        Doctor doctor = new Doctor(LogInID, LoggedInUserDetails[0]);
                        doctor.MainMenu();

                        // Below code executes when user chose log out from admin menu
                        LoggedIn = !LoggedIn;// This should set the log in state to false
                        currentUserType = userType.LoggedOut;
                        LoggedInUserDetails = new string[0];

                        break;
                    case userType.Patient:
                        /*Console.WriteLine("The system is now at Patient state");
                        Console.ReadKey();*/


                        Patient patient = new Patient(LogInID, LoggedInUserDetails[0]);
                        patient.MainMenu();

                        // Below code executes when user chose log out from admin menu
                        LoggedIn = !LoggedIn;// This should set the log in state to false
                        currentUserType = userType.LoggedOut;
                        LoggedInUserDetails = new string[0];


                        break;
                    default:
                        Console.WriteLine("Here is the Default state ;p");
                        Console.ReadKey();
                        break;
                }

                // Reset all lists holding log in details, 
                // so if admin created a new doctor/patient, 
                // and logged out for logging in as the new doctor/patient, 
                // the new login detail lists will get updated with new file reading at the beginning of do.
                adminFileLines = new List<String>();
                doctorFileLines = new List<String>();
                patientFileLines = new List<String>();
            }
            while (!LoggedIn); 

            

        }

        public void TestLogInCredentials(String LogInID, String LogInPW)
        {

            //adminFilelines = FileManager.ReadStringArrayFromFile("Admins.txt");
            /*adminFileLines = FileManager.ReadStringListFromFile("Admins.txt");*/

            if (LogInID == null && LogInPW == null) 
            {
                Console.WriteLine("Empty Log In Credentials! \nPress any keys to retry");
                Console.ReadKey();
                Console.Clear();
                return;
                //
            }

            foreach(string adminDetail in adminFileLines)
            {
                //Console.WriteLine($"{adminDetail}");
                //Console.WriteLine("{0}", adminDetail);

                String[] details = adminDetail.Split(',');

                if (LogInID == details[1])
                {
                    if (LogInPW == details[2])
                    {
                        // If ID and passwords all matches
                        Console.WriteLine("Autenticated as Admin {0}", details[0]);
                        Console.ReadKey();
                        Console.Clear();
                        //name = details[0];
                        LoggedInUserDetails = details;
                        //Admin admin = new Admin(details[1], details[0]);
                        currentUserType = userType.Admin;
                        LoggedIn = !LoggedIn;
                        //admin.MainMenu();
                        return;
                    }
                    else
                    {
                        // If password does not match
                        Console.WriteLine("Incorrect Password! \nPress any keys to retry");
                        Console.ReadKey();
                        Console.Clear();
                        return;
                    }
                }

                // If the code reaches here,
                // that means there are no matching IDs in the txt file
                /*Console.WriteLine("Incorrect user ID! \nPress any keys to retry");
                Console.ReadKey();
                Console.Clear();*/
                //return;                

            }

            foreach (string adminDetail in adminFileLines)
            {
                //Console.WriteLine($"{adminDetail}");
                //Console.WriteLine("{0}", adminDetail);

                String[] details = adminDetail.Split(',');

                if (LogInID == details[1])
                {
                    if (LogInPW == details[2])
                    {
                        // If ID and passwords all matches
                        Console.WriteLine("Autenticated as Admin {0}", details[0]);
                        Console.ReadKey();
                        Console.Clear();
                        //name = details[0];
                        LoggedInUserDetails = details;
                        //Admin admin = new Admin(details[1], details[0]);
                        currentUserType = userType.Admin;
                        LoggedIn = !LoggedIn;
                        //admin.MainMenu();
                        return;
                    }
                    else
                    {
                        // If password does not match
                        Console.WriteLine("Incorrect Password! \nPress any keys to retry");
                        Console.ReadKey();
                        Console.Clear();
                        return;
                    }
                }

                // If the code reaches here,
                // that means there are no matching IDs in the txt file
                /*Console.WriteLine("Incorrect user ID! \nPress any keys to retry");
                Console.ReadKey();
                Console.Clear();*/
                //return;                

            }

            foreach (string doctorDetail in doctorFileLines)
            {
                //Console.WriteLine($"{adminDetail}");
                //Console.WriteLine("{0}", adminDetail);

                String[] details = doctorDetail.Split(',');

                if (LogInID == details[1])
                {
                    if (LogInPW == details[2])
                    {
                        // If ID and passwords all matches
                        Console.WriteLine("Autenticated as Doctor {0}", details[0]);
                        Console.ReadKey();
                        Console.Clear();
                        //name = details[0];
                        LoggedInUserDetails = details;
                        //Admin admin = new Admin(details[1], details[0]);
                        currentUserType = userType.Doctor;
                        LoggedIn = !LoggedIn;
                        //admin.MainMenu();
                        return;
                    }
                    else
                    {
                        // If password does not match
                        Console.WriteLine("Incorrect Password! \nPress any keys to retry");
                        Console.ReadKey();
                        Console.Clear();
                        return;
                    }
                }

                // If the code reaches here,
                // that means there are no matching IDs in the txt file
                /*Console.WriteLine("Incorrect user ID! \nPress any keys to retry");
                Console.ReadKey();
                Console.Clear();*/
                //return;                

            }

            foreach (string patientDetail in patientFileLines)
            {
                //Console.WriteLine($"{adminDetail}");
                //Console.WriteLine("{0}", adminDetail);

                String[] details = patientDetail.Split(',');

                if (LogInID == details[1])
                {
                    if (LogInPW == details[2])
                    {
                        // If ID and passwords all matches
                        Console.WriteLine("Autenticated as Patient {0}", details[0]);
                        Console.ReadKey();
                        Console.Clear();
                        //name = details[0];
                        LoggedInUserDetails = details;
                        //Admin admin = new Admin(details[1], details[0]);
                        currentUserType = userType.Patient;
                        LoggedIn = !LoggedIn;
                        //admin.MainMenu();
                        return;
                    }
                    else
                    {
                        // If password does not match
                        Console.WriteLine("Incorrect Password! \nPress any keys to retry");
                        Console.ReadKey();
                        Console.Clear();
                        return;
                    }
                }

                // If the code reaches here,
                // that means there are no matching IDs in the txt file
                /*Console.WriteLine("Incorrect user ID! \nPress any keys to retry");
                Console.ReadKey();
                Console.Clear();*/
                //return;                

            }

            /*if (LogInID == correctDoctorID && LogInPW == correctDoctorPW)
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
            }*/


            // If the code reaches here,
            // that means there are no matching IDs in the txt file

            //LoggedIn = !LoggedIn; // This should set LoggedIn to true at all times. 
            /*Console.WriteLine("Wrong Password! \nPress any keys to retry. ");*/
            Console.WriteLine("Wrong ID! \nPress any keys to retry. ");
            Console.ReadKey();
            Console.Clear();

            //FileManager.ReadFromFile(LogInID);
        }
    }
        
}