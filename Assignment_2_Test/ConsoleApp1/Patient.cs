using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        //private Doctor assignedDoctorID;
        private string assignedDoctorID;

        private List<string> appointmentIDs = new List<string>();

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

            try
            {
                this.assignedDoctorID = patientDetails[3];

                for (int i = 4; i < patientDetails.Length - 1; i++)
                {
                    this.appointmentIDs.Add(patientDetails[i]);
                }
            }
            catch (IndexOutOfRangeException e)
            {

            }
                     
            /*if (patientDetails[2] != null || patientDetails[2] != "")
            {
                assignedDoctorID = util.GetDoctorByID(patientDetails[2]);
            }*/
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
                    util.WipeUserData();
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
                            ListDoctorDetails();
                            break;
                        case 3:                            
                            Console.WriteLine("Listing all appointments");
                            Console.ReadKey();
                            Console.Clear();
                            ListAllAppointments();
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
            /*Console.WriteLine("Now inside BookAppointment()");
            Console.ReadKey();*/

            List<string> appointmentInfo = new List<string>();

            appointmentInfo.Add(Patient_ID);

            /*Console.Write("assignedDoctorID is: {0}\n", assignedDoctorID);
            Console.ReadKey();*/

            //if (assignedDoctorID == null || assignedDoctorID.DoctorID == "")
            if (assignedDoctorID == null || assignedDoctorID == "")
            {
                string inputID;

                // Making sure that user is entering a valid doctor ID
                do
                {
                    Console.Clear();
                    Console.WriteLine("You are not registered with any doctors!");
                    util.PrintAllDoctors();
                    Console.WriteLine("\nChoose a doctor from below by typing the corresponding doctor ID: ");                    
                    inputID = Console.ReadLine();
                }
                while (!util.CheckDoctorExistsByID(inputID));
                // While there is not a valid doctor existing with this ID

                //string inputID = Console.ReadLine();
                /*if (util.CheckDoctorExistsByID(inputID))// Means there is a valid doctor existing with this ID
                {
                    //inputID = Console.ReadLine();
                    appointmentInfo.Add(inputID);
                }*/

                assignedDoctorID = inputID;

                FileManager.AppendAtTheEndOfLine("Patients.txt", Patient_ID, assignedDoctorID);
            }

            appointmentInfo.Add(assignedDoctorID);

            Doctor assignedDoctor = util.GetDoctorByID(assignedDoctorID);

            Console.WriteLine("You are booking a new appointment with {0}", assignedDoctor.Name);
            Console.WriteLine("Description of the appointment: ");
            string appointmentDetails = Console.ReadLine();
            //Console.WriteLine(appointmentDetails);
            appointmentInfo.Add(appointmentDetails);

            util.AddAppointment(appointmentInfo);

            //FileManager.AppendAtTheEndOfLine("Patients.txt", Patient_ID, assignedDoctorID);

            Console.WriteLine("The appointment has been booked successfully.\nPress any keys to return to menu");
            Console.ReadKey();
            Console.Clear();
        }// end of: BookAppointments()

        private void ListAllAppointments()
        {
            Console.WriteLine("Appointments for {0}: ", this.Name);
            Console.ReadKey();

            foreach (string appointmentID in appointmentIDs)
            {
                Console.WriteLine(util.GetAppointmentByID(appointmentID).ToString());
                
                //Console.WriteLine()
            }

            Console.WriteLine("\nPress any keys to return to menu.");
            Console.ReadKey();
            Console.Clear();
        }

        private void ListDoctorDetails()
        {
            Console.WriteLine("Your doctor \n");
            Console.WriteLine(util.GetDoctorByID(assignedDoctorID).ToString());
            Console.WriteLine("\nPress any keys to return to menu");
            Console.ReadKey();
            Console.Clear();
        }

        private void ListPatientDetails()
        {
            Console.WriteLine("{0}'s Details \n", this.Name);
            Console.WriteLine(ToString());
            Console.WriteLine("\nPress any keys to return to menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

