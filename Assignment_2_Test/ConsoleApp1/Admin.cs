using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class Admin: User
    {
        private string Admin_ID;

        public string MainMenuInputString = "";
        public int MainMenuInput = 0;

        public bool LoggedIn = true;

        private Util util;
        
        public Admin(string admin_ID, string name)// :base(Name)
        {
            this.Admin_ID = admin_ID;
            this.Name = name;
        }

        public Admin(string admin_ID, string[] adminDetails)
        {
            this.Admin_ID = admin_ID;
            this.Name = adminDetails[0];
        }

        // Constructor for current logged in users. 
        public Admin(string admin_ID, string[] adminDetails, Util util)
        {
            this.Admin_ID = admin_ID;
            this.Name = adminDetails[0];
            this.util = util;// Receiving the util object initialised from Program.cs
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

                    switch (MainMenuInput)
                    {
                        case 6:
                            Console.WriteLine("Adding a new patient");
                            Console.ReadKey();
                            Console.Clear();
                            AddPatient();
                            break;
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

            
        }// end of MainMenu()

        public void AddPatient()
        {
            Console.WriteLine("Inside AddPatient() function, input details");
            Console.ReadKey();

            List<String> inputDetails = new List<String>();

            bool comfirmAdding = false;
            bool finishedAdding = false;

            do
            {
                Console.WriteLine("Input Patient Name: ");
                inputDetails.Add(Console.ReadLine());

                Console.WriteLine("Your unique PatientID is: ");
                String uniqueID = util.GenerateUniquePatientID();
                Console.WriteLine(uniqueID);
                inputDetails.Add(uniqueID);

                /*Console.WriteLine("Input Patient ID: ");
                //inputDetails.Add(Console.ReadLine());
                String inputId = Console.ReadLine();
                if (inputId != null && inputId != "")
                {
                    if (!util.CheckPatientExistsByID(inputId))
                    {
                        inputDetails.Add(inputId);
                    }
                    else
                    {
                        Console.WriteLine("Patient with same ID already exists.\nPress any keys to retry");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                }*/

                Console.WriteLine("Input Patient Password: ");
                inputDetails.Add(Console.ReadLine());

                do
                {
                    Console.WriteLine("Comfirm Adding? Y/N");
                    String input = Console.ReadLine();
                    if (input == null || input == "")
                    {
                        Console.WriteLine("Invalid Input, press any keys to try again.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (input == "N")
                    {
                        bool retryValid = false;
                        do
                        {
                            Console.WriteLine("Do you want to input details again? Y/N");
                            String inputTwo = Console.ReadLine();
                            if (inputTwo == null || inputTwo == "")
                            {
                                Console.WriteLine("Invalid Input, press any keys to try again.");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (inputTwo == "N")
                            {
                                Console.WriteLine("Cancelling adding patient operation.\nPress any keys to return to main menu. ");
                                Console.ReadKey();
                                Console.Clear();
                                return;
                                /*retryValid = true;
                                comfirmAdding = true;
                                finishedAdding = true;*/
                            }
                            else if (inputTwo == "Y")
                            {
                                Console.WriteLine("Adding patient again with new detail inputs. ");
                                Console.ReadKey();
                                Console.Clear();
                                inputDetails = new List<String>();
                                retryValid = true;
                                comfirmAdding = true;
                            }
                            /*Console.WriteLine("Invalid Input, press any keys to try again.");
                            Console.ReadKey();
                            Console.Clear();*/
                            Console.Clear();
                        }
                        while (!retryValid);
                    }
                    else if (input == "Y")
                    {
                        Console.WriteLine("Comfirmed adding.\nPress any keys to continue.");
                        comfirmAdding = true;
                        finishedAdding = true;
                    }
                    /*Console.WriteLine("Invalid Input, press any keys to try again.");
                    Console.ReadKey();*/
                    Console.Clear();
                }
                while (!comfirmAdding);
            }
            while (!finishedAdding);

            // Creating the string line for appending into the file
            //Console.WriteLine("Added patients to database.\nPress any keys to continue.");
            String finalAdding = "\n";

            foreach (string detail in inputDetails)
            {
                Console.WriteLine("{0}", detail);
                finalAdding += detail;
                finalAdding += ",";
            }

            /*Console.WriteLine(finalAdding.Length);
            finalAdding.Remove(finalAdding.Length - 1);
            finalAdding.Remove(finalAdding.Length - 1);
            finalAdding.Remove(finalAdding.Length - 1);*/

            Console.WriteLine(finalAdding); 

            Console.ReadKey();

            //FileManager.AppendToFileEnd("Patients.txt", finalAdding);

            Console.Clear();

        }


    }// end of internal class Admin: User
}
