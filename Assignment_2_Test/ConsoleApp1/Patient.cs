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
        public string Patient_ID { get; set; }

        public string MainMenuInputString = "";
        public int MainMenuInput = 0;

        public bool LoggedIn = true;

        private Util util;

        /*public Patient(string patient_ID, string name)
        {
            this.Patient_ID = patient_ID;
            this.Name = name;
        }*/

        // Patient Constructor as storing objects
        public Patient(string patient_ID, string[] patientDetails)
        {
            this.Patient_ID = patient_ID;
            this.Name = patientDetails[0];
        }

        // Patient Constructor as current logged in user
        public Patient(string patient_ID, string[] patientDetails, Util util)
        {
            this.Patient_ID = patient_ID;
            this.Name = patientDetails[0];
            this.util = util;
        }

        public override string ToString()
        {
            //return base.ToString();
            return (this.Name + ", " + this.Patient_ID);
        }

        public void MainMenu()
        {
            do { 
                /*Console.WriteLine("This would display the main menu for the patient");
                Console.WriteLine("The Patient ID is {0} and the Name is {1}", this.Patient_ID, this.Name);*/

                Console.WriteLine("Welcome to DOTNET Hospital Management System, Patient {0}", this.Name);

                Console.WriteLine("Please choose an option: ");
                Console.WriteLine("1. List patient details");
                Console.WriteLine("2. List my doctor details");
                Console.WriteLine("3. List all appointments");
                Console.WriteLine("4. Book appointment");
                Console.WriteLine("5. Log Out");
                Console.WriteLine("6. Exit Application");
                Console.WriteLine("\nYour input for choosing option is: ");

                //MainMenuInput = Convert.ToInt32(Console.ReadLine());
                MainMenuInputString = Console.ReadLine();
                //Console.WriteLine("MainMenuInputString is {0}", MainMenuInputString);
                //MainMenuInput = Convert.ToInt32(Console.ReadLine());
                try
                {

                    util.InitialiseUserData();

                    MainMenuInput = Convert.ToInt32(MainMenuInputString);
                    //Console.WriteLine("MainMenuInput is {0}", MainMenuInput);

                    switch (MainMenuInput)
                    {
                        case 1:
                            Console.WriteLine("Displaying my details");
                            Console.ReadKey();
                            Console.Clear();
                            ListPatientDetails();
                            break;
                        case 2:
                            Console.WriteLine("Displaying my doctor's details");
                            Console.ReadKey();
                            Console.Clear();
                            //CheckPatientDetails();
                            break;
                        case 3:                            
                            Console.WriteLine("Listing all appointments");
                            Console.ReadKey();
                            Console.Clear();
                            //AddPatient();
                            break;
                        case 4:
                            Console.WriteLine("Booking an appointment");
                            Console.ReadKey();
                            Console.Clear();
                            BookAppointment();
                            break;
                        case 5:
                            Console.WriteLine("\nLogging out, Thank you!\nPress any keys to continue");
                            Console.ReadKey();
                            Console.Clear();
                            LoggedIn = !LoggedIn; // Logging out of admin user and stop admin menu displaying. 
                            return;
                        case 6:
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
                    }// end of: switch block

                    util.WipeUserData();
                }
                catch (FormatException e)
                {
                    Console.WriteLine("\nInvalid Input format. \nPress any keys to retry");
                    Console.ReadKey();
                    Console.Clear();
                }// end of: try block

            }
            while (LoggedIn);
        }// end of: MainMenu()

        private void BookAppointment()
        {
            Console.WriteLine("Now inside BookAppointment()");
            Console.ReadKey();

            Console.WriteLine("You are booking a new appointment with (Your Doctor's Name Here)");
            Console.WriteLine("Description of the appointment: ");
            string appointmentDetails = Console.ReadLine();
            Console.WriteLine(appointmentDetails);

            Console.WriteLine("The appointment has been booked successfully.\nPress any keys to return to menu");
            Console.ReadKey();
        }

        private void ListPatientDetails()
        {
            Console.WriteLine(ToString());
            Console.WriteLine("\nYour patient details are all displayed.\nPress any keys to return to menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

