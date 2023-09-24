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

        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }

        public string MainMenuInputString = "";
        public int MainMenuInput = 0;

        public bool LoggedIn = true;

        //private Doctor assignedDoctorID;
        private string assignedDoctorID;
        private string assignedDoctorName;

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

            this.email = patientDetails[1];
            this.phone = patientDetails[2];
            this.address = patientDetails[3];

            // Below code will try to initialise the assignedDoctorName attribute for ToString().
            // The Util class created here won't be used for future operation,
            // if a Patient object is created through this constructor. 
            Util util = new Util();
            try
            {
                this.assignedDoctorID = patientDetails[6];
                this.assignedDoctorName = util.GetDoctorByID(this.assignedDoctorID).Name;

                for (int i = 7; i < patientDetails.Length - 1; i++)
                {
                    this.appointmentIDs.Add(patientDetails[i]);
                }
            }
            catch (Exception e)
            {

            }
            /*catch (IndexOutOfRangeException e)
            {

            }*/


        }

        // Patient Constructor as current logged in user
        public Patient(string patient_ID, string[] patientDetails, Util util)
        {
            this.Patient_ID = patient_ID;
            this.Name = patientDetails[0];

            this.email = patientDetails[1];
            this.phone = patientDetails[2];
            this.address = patientDetails[3];

            //this.

            this.util = util;

            try
            {
                this.assignedDoctorID = patientDetails[6];
                this.assignedDoctorName = util.GetDoctorByID(this.assignedDoctorID).Name;

                for (int i = 7; i < patientDetails.Length - 1; i++)
                {
                    this.appointmentIDs.Add(patientDetails[i]);
                }
            }
            catch (Exception e)
            {

            }
            /*catch (IndexOutOfRangeException e)
            {

            }*/
                     
            /*if (patientDetails[2] != null || patientDetails[2] != "")
            {
                assignedDoctorID = util.GetDoctorByID(patientDetails[2]);
            }*/
        }

        public override string ToString()
        {
            //return base.ToString();
            //return (this.Name + ", " + this.Patient_ID);
            return (this.Name + 
                " | " + 
                this.assignedDoctorName + 
                " | " + 
                this.email + 
                " | " + 
                this.phone + 
                " | " + 
                this.address);
        }

        public void PrintHeader()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("| DOTNET Hospital Management System |");
            Console.WriteLine("|-----------------------------------|");
            Console.WriteLine("|           Patient Menu            |");
            Console.WriteLine("-------------------------------------");
        }

        public void MainMenu()
        {
            do {
                /*Console.WriteLine("This would display the main menu for the patient");
                Console.WriteLine("The Patient ID is {0} and the Name is {1}", this.Patient_ID, this.Name);*/

                PrintHeader();

                Console.WriteLine("\nWelcome to DOTNET Hospital Management System, Patient {0}\n", this.Name);

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
                            /*Console.WriteLine("Displaying my details");
                            Console.ReadKey();*/
                            Console.Clear();
                            PrintHeader();
                            ListPatientDetails();
                            break;
                        case 2:
                            /*Console.WriteLine("Displaying my doctor's details");
                            Console.ReadKey();*/
                            Console.Clear();
                            PrintHeader();
                            ListDoctorDetails();
                            break;
                        case 3:                            
                            /*Console.WriteLine("Listing all appointments");
                            Console.ReadKey();*/
                            Console.Clear();
                            PrintHeader();
                            ListAllAppointments();
                            break;
                        case 4:
                            /*Console.WriteLine("Booking an appointment");
                            Console.ReadKey();*/
                            Console.Clear();
                            PrintHeader();
                            BookAppointment();
                            break;
                        case 5:
                            Console.WriteLine("\nLogging out, Thank you!\nPress any keys to continue.");
                            Console.ReadKey();
                            Console.Clear();
                            LoggedIn = !LoggedIn; // Logging out of admin user and stop admin menu displaying. 
                            return;
                        case 6:
                            Console.WriteLine("\nExiting application, Thank you!\nPress any keys to continue.");
                            Console.ReadKey();

                            Environment.Exit(0);

                            //Console.Clear();
                            //LoggedIn = !LoggedIn; // Logging out of admin user and stop admin menu displaying. 
                            return;
                        //break;
                        default:
                            Console.WriteLine("\nIncorrect number Input. \nPress any keys to retry.");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }// end of: switch block

                    
                }
                catch (FormatException e)
                {
                    Console.WriteLine("\nInvalid Input format. \nPress any keys to retry.");
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
                bool isFound = false;
                string inputID;

                // Making sure that user is entering a valid doctor ID
                do
                {
                    Console.Clear();
                    PrintHeader();
                    Console.WriteLine("You are not registered with any doctors!");
                    util.PrintAllDoctors(false);
                    Console.WriteLine("\nChoose a doctor from below by typing the number option: ");
                    inputID = Console.ReadLine();

                    try
                    {
                        Doctor doctor = util.GetDoctorByIndex(Convert.ToInt32(inputID));
                        isFound = true;
                        assignedDoctorID = doctor.DoctorID;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("\nInvalid Input. Returning to menu. ");
                    }
                }
                while (!isFound);
                //while (!util.CheckDoctorExistsByID(inputID));
                // While there is not a valid doctor existing with this ID

                //string inputID = Console.ReadLine();
                /*if (util.CheckDoctorExistsByID(inputID))// Means there is a valid doctor existing with this ID
                {
                    //inputID = Console.ReadLine();
                    appointmentInfo.Add(inputID);
                }*/

                //assignedDoctorID = inputID;

                FileManager.AppendAtTheEndOfLine("Patients.txt", Patient_ID, assignedDoctorID);
            }

            appointmentInfo.Add(assignedDoctorID);

            Doctor assignedDoctor = util.GetDoctorByID(assignedDoctorID);

            Console.WriteLine("You are booking a new appointment with {0}", assignedDoctor.Name);
            Console.WriteLine("Description of the appointment: ");
            string appointmentDetails = Console.ReadLine();
            //Console.WriteLine(appointmentDetails);
            appointmentInfo.Add(appointmentDetails);

            string bookingID = util.AddAppointment(appointmentInfo);
            appointmentIDs.Add(bookingID);

            //FileManager.AppendAtTheEndOfLine("Patients.txt", Patient_ID, assignedDoctorID);

            Console.WriteLine("The appointment has been booked successfully.\nPress any keys to return to menu");
            Console.ReadKey();
            Console.Clear();
        }// end of: BookAppointments()

        private void ListAllAppointments()
        {
            Console.WriteLine("Appointments for {0}: ", this.Name);
            //Console.ReadKey();

            if (appointmentIDs.Count == 0)
            {
                Console.WriteLine("You currently do not have any appointments");
            }

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
            Console.WriteLine("Your doctor: \n");
            try
            {
                Console.WriteLine(util.GetDoctorByID(assignedDoctorID).ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("You currently do not have any assigned doctors");
            }
            
            Console.WriteLine("\nPress any keys to return to menu");
            Console.ReadKey();
            Console.Clear();
        }

        private void ListPatientDetails()
        {
            Console.WriteLine("{0}'s Details: \n", this.Name);
            //Console.WriteLine(ToString());
            Console.WriteLine("Patient ID: {0}", this.Patient_ID);
            Console.WriteLine("Full Name: {0}", this.Name);
            Console.WriteLine("Address: {0}", this.address);
            Console.WriteLine("Email: {0}", this.email);
            Console.WriteLine("Phone: {0}", this.phone);

            Console.WriteLine("\nPress any keys to return to menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

