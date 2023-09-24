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

        public string MainMenuInputString = "";
        public int MainMenuInput = 0;

        public bool LoggedIn = true;

        private List<string> appointmentIDs = new List<string>();
        private List<string> patientIDs = new List<string>();   

        private Util util;

        /*public Doctor(string doctor_ID, string name)// :base(Name)
        {
            this.DoctorID = doctor_ID;
            this.Name = name;
        }*/

        // Doctor Constructor as storing objects
        public Doctor(string doctor_ID, string[] doctorDetails)// :base(Name)
        {
            this.DoctorID = doctor_ID;
            this.Name = doctorDetails[0];
        }

        // Doctor Constructor as currently logged in user
        public Doctor(string doctor_ID, string[] doctorDetails, Util util)// :base(Name)
        {
            this.DoctorID = doctor_ID;
            this.Name = doctorDetails[0];
            this.util = util;

            try
            {
                //this.assignedDoctorID = patientDetails[3];

                for (int i = 3; i < doctorDetails.Length - 1; i++)
                {
                    this.appointmentIDs.Add(doctorDetails[i]);
                    
                }
                PopulatePatientList();
            }
            catch (IndexOutOfRangeException e)
            {

            }
        }

        /*public string DoctorID
        {
            get ==> ReturnTypeEncoder
        }*/

        public override string ToString()
        {
            //return base.ToString();
            return (this.Name + ", " + this.DoctorID);
        }

        public void MainMenu()
        {
            /*Console.WriteLine("This would display the main menu for the Doctor");
            Console.WriteLine("The Doctor ID is {0} and the Name is {1}", this.DoctorID, this.Name);*/

            do
            {
                /*Console.WriteLine("This would display the main menu for the patient");
                Console.WriteLine("The Patient ID is {0} and the Name is {1}", this.Patient_ID, this.Name);*/

                Console.WriteLine("Welcome to DOTNET Hospital Management System, Doctor {0}", this.Name);

                Console.WriteLine("Please choose an option: ");
                Console.WriteLine("1. List doctor details");
                Console.WriteLine("2. List patients");
                Console.WriteLine("3. List appointments");
                Console.WriteLine("4. Check particular patient");
                Console.WriteLine("5. List appointments with patient");
                Console.WriteLine("6. Log out");
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
                            ListDoctorDetails();
                            break;
                        case 2:
                            Console.WriteLine("Displaying all patients");
                            Console.ReadKey();
                            Console.Clear();
                            ListAllPatients();// Needs work
                            break;
                        case 3:
                            Console.WriteLine("Listing all appointments");
                            Console.ReadKey();
                            Console.Clear();
                            ListAllAppointments();
                            break;
                        case 4:
                            Console.WriteLine("Checking a particular patient");
                            Console.ReadKey();
                            Console.Clear();
                            CheckSinglePatient();// Needs work
                            break;
                        case 5:
                            Console.WriteLine("List appointments with patient");
                            Console.ReadKey();
                            Console.Clear();
                            ListAppointmentByPatient();// Needs work
                            break;
                        case 6:
                            Console.WriteLine("\nLogging out, Thank you!\nPress any keys to continue.");
                            Console.ReadKey();
                            Console.Clear();
                            LoggedIn = !LoggedIn; // Logging out of admin user and stop admin menu displaying. 
                            return;
                        case 7:
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
        }

        // Retrieve all patients that has bookings with currently logged in doctor.
        // This should populate the patientIDs list with unique patient ID that is associated with this doctor
        private void PopulatePatientList() 
        {
            List<Appointment> bookingLists = new List<Appointment>();              

            foreach (string bookingID in appointmentIDs)
            {
                bookingLists.Add(util.GetAppointmentByID(bookingID));
            }

            foreach (Appointment booking in bookingLists)
            {
                if (!patientIDs.Contains(booking.bookedPatient.Patient_ID))
                {
                    patientIDs.Add(booking.bookedPatient.Patient_ID);
                }
                //patientIDs.Add()
            }
            
        }

        private void ListAppointmentByPatient()
        {
            //throw new NotImplementedException();

            //throw new NotImplementedException();
            Console.WriteLine("Listed appointments with a particulat patient");
            Console.ReadKey();

            string patientID = "";
            bool isLooping = true;

            do
            {// Checking if input ID has a valid patient counter part. 
                patientID = "";
                Console.WriteLine("Enter the ID of the patient you would like to view appointments for: ");
                patientID = Console.ReadLine();

                if (!util.CheckPatientExistsByID(patientID))
                {
                    Console.WriteLine("Patient Not Found. Retry? Y/N");
                    string input = Console.ReadLine();
                    if (input == null || input == "")
                    {
                        Console.WriteLine("Invalid Input, press any keys to try again.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (input == "N")
                    {
                        Console.WriteLine("Cancelled operation. Returning to main menu.");
                        Console.ReadKey();
                        //isLooping = false;
                        Console.Clear();
                        return;
                    }
                    else if (input == "Y")
                    {
                        Console.Clear();
                        //isLooping = true;
                        continue;
                    }
                }
                else
                {
                    isLooping = false;
                }

            }
            while (isLooping);

            foreach (string bookingID in appointmentIDs)
            {
                Appointment booking = util.GetAppointmentByID(bookingID);
                if (booking.bookedPatient.Patient_ID == patientID)
                {
                    Console.WriteLine(booking.ToString());
                }
            }

            Console.WriteLine("\nPress any keys to return to menu. ");
            Console.ReadKey();
            Console.Clear();

            //Console.WriteLine(util.GetPatientByID(patientID).ToString());

        }

        private void CheckSinglePatient()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Checking a particular patient by ID");
            Console.ReadKey();

            string patientID = "";
            bool isLooping = true;

            do
            {// Checking if input ID has a valid patient counter part. 
                patientID = "";
                Console.WriteLine("Enter the ID of the patient to check: ");
                patientID = Console.ReadLine();

                if (!util.CheckPatientExistsByID(patientID))
                {
                    Console.WriteLine("Patient Not Found. Retry? Y/N");
                    string input = Console.ReadLine();
                    if (input == null || input == "")
                    {
                        Console.WriteLine("Invalid Input, press any keys to try again.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (input == "N")
                    {
                        Console.WriteLine("Cancelled operation. Returning to main menu.");
                        Console.ReadKey();
                        //isLooping = false;
                        Console.Clear();
                        return;
                    }
                    else if (input == "Y")
                    {
                        Console.Clear();
                        //isLooping = true;
                        continue;
                    }
                }
                else
                {
                    isLooping = false;
                }
                    
            }
            while (isLooping);

            Console.WriteLine(util.GetPatientByID(patientID).ToString());

            Console.WriteLine("\nPress any keys to return to menu. ");
            Console.ReadKey();
            Console.Clear();

        }

        private void ListAllAppointments()
        {
            Console.WriteLine("Listing all appointments");
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

        private void ListAllPatients()
        {
            Console.WriteLine("Listing all patients");
            Console.ReadKey();

            foreach (string patientID in patientIDs)
            {
                try
                {
                    Console.WriteLine(util.GetPatientByID(patientID).ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
                

                //Console.WriteLine()
            }

            Console.WriteLine("\nPress any keys to return to menu.");
            Console.ReadKey();
            Console.Clear();
        }

        private void ListDoctorDetails()
        {
            Console.WriteLine("Doctor {0}'s Details \n", this.Name);
            Console.WriteLine(ToString());
            Console.WriteLine("\nPress any keys to return to menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
