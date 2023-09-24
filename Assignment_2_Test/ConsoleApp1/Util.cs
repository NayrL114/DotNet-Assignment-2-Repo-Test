using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Util
    {
        public List<Admin> adminList = new List<Admin>();
        public List<Doctor> doctorList = new List<Doctor>();
        public List<Patient> patientList = new List<Patient>();

        /*//private String[] adminFilelines;
        public List<String> adminFileLines;
        //private String[] doctorFilelines;
        public List<String> doctorFileLines;
        //private String[] patientFilelines;
        public List<String> patientFileLines;
        //private String[] recordedAppointments;
        public List<String> bookedAppointments;*/

        public List<Appointment> bookedAppointments = new List<Appointment>();

        public string latestBookingID;

        // ALL FUNCTION WAS STATIC IN PREVIOUS UTIL CLASS DESIGN

        // Populates all three user lists
        public void InitialiseUserData()
        {
            // If there are already contents inside lists, don't do anything
            //if (patientList.Count != 0)
            if (patientList.Count != 0 
                && doctorList.Count != 0 
                && adminList.Count != 0 
                && bookedAppointments.Count != 0)
            {
                return;
            }

            try
            {
                List<string> adminFileLines = FileManager.ReadStringListFromFile("Admins.txt");
                List<string> doctorFileLines = FileManager.ReadStringListFromFile("Doctors.txt");
                List<string> patientFileLines = FileManager.ReadStringListFromFile("Patients.txt");

                List<string> appointmentFileLines = FileManager.ReadStringListFromFile("Appointments.txt");

                foreach (string details in adminFileLines)
                {
                    string[] detail = details.Split(',');
                    if (detail[0] == "")
                    {
                        continue;
                    }
                    Admin admin = new Admin(detail[1], detail);
                    adminList.Add(admin);
                }

                foreach (string details in doctorFileLines)
                {
                    string[] detail = details.Split(',');
                    if (detail[0] == "")
                    {
                        continue;
                    }
                    Doctor doctor = new Doctor(detail[4], detail);
                    doctorList.Add(doctor);
                }

                foreach (string details in patientFileLines)
                {
                    string[] detail = details.Split(',');
                    if (detail[0] == "")
                    {
                        continue;
                    }
                    //Console.WriteLine("Creating Patient {0}", detail[0]);
                    Patient patient = new Patient(detail[4], detail, this);
                    patientList.Add(patient);
                }

                foreach (string details in appointmentFileLines)
                {
                    string[] detail = details.Split(',');
                    if (detail[0] == "")
                    {
                        continue;
                    }
                    Appointment appointment = new Appointment(detail[0], 
                        GetPatientByID(detail[1]), 
                        GetDoctorByID(detail[2]), 
                        detail[3]);
                    bookedAppointments.Add(appointment);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                //onsole.WriteLine("File not found");
            }
            /*catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }*/
            

            
        }

        // Empties all three user lists.
        public void WipeUserData()
        {
            adminList = new List<Admin>();
            doctorList = new List<Doctor>();
            patientList = new List<Patient>();

            bookedAppointments = new List<Appointment>();
        }

        // Code section related to patient handling

        // Generates an unique Patient ID, 
        // Format is: 0(XXXX), where X can be any numbers between 0-9
        public string GenerateUniquePatientID()
        {
            //return "114514";
            bool isDuplicated = false;
            Random rand = new Random();
            string patientID = "";

            do
            {
                patientID = "";
                patientID += "0";
                //patientID += "0";
                patientID += Convert.ToString(rand.Next(1000, 9999));
                //Console.WriteLine(patientID);
                isDuplicated = CheckPatientExistsByID(patientID);
            }
            while (isDuplicated);

            return patientID;
            /*string patientID = "";
            patientID += "0";
            patientID += "0";*/
            //patientID += Random.Next(0)
        }

        // Generates an unique Doctor ID, 
        // Format is: 10(XXX), where X can be any numbers between 0-9
        internal string GenerateUniqueDoctorID()
        {
            //return "114514";
            bool isDuplicated = false;
            Random rand = new Random();
            string patientID = "";

            do
            {
                patientID = "";
                patientID += "10";
                //patientID += "0";
                patientID += Convert.ToString(rand.Next(100, 999));
                //Console.WriteLine(patientID);
                isDuplicated = CheckDoctorExistsByID(patientID);
            }
            while (isDuplicated);

            return patientID;
            /*string patientID = "";
            patientID += "0";
            patientID += "0";*/
            //patientID += Random.Next(0)
        }

        // Checking if a patient with passed in ID already exists. 
        // Return TRUE if exists, 
        // Return FALSE if not exists
        public bool CheckPatientExistsByID(string ID)
        {
            if (patientList.Count == 0 || ID == null)
            {
                //throw new Exception("Patient list is not initialised");
                return false;
            }

            for (int i = 0; i < patientList.Count; i++)
            {
                if (patientList[i].Patient_ID == ID)
                {
                    //return patientList[i];
                    return true;
                }
            }
            //throw new Exception("Patient not found");
            return false;
        }

        // Get a patient object stored in the patientList by passed in ID
        public Patient GetPatientByID(string ID) {
            if (patientList.Count == 0 || ID == null)
            {
                throw new Exception("No patients stored in the database.");
                //return false;
            }

            foreach(Patient patient in patientList)
            {
                //Console.WriteLine(patient.Patient_ID);
                if (patient.Patient_ID == ID) { return patient; }
            }

            /*for (int i = 0; i < patientList.Count; i++)
            {
                if (patientList[i].Patient_ID == ID)
                {
                    return patientList[i];
                    //return true;
                }
            }*/
            throw new Exception("Patient not found.");
            //return false;
        }

        // Print all patients.ToString() on to screen
        public void PrintAllPatients()
        {
            if (patientList.Count == 0)
            {
                Console.WriteLine("No patient stored in the database. ");
                //return false;
            }

            //Console.WriteLine("Printing all patient now");

            foreach (Patient patient in patientList)
            {
                //Console.WriteLine("Printing a patient");
                Console.WriteLine(patient.ToString());
                //if (patient.Patient_ID == ID) { return patient; }
            }
        }

        // Get a doctor object stored in the doctorList by passed in ID
        public Doctor GetDoctorByID(string ID) /*throws Exception*/
        {
            if (doctorList.Count == 0 || ID == null)
            {
                throw new Exception("No doctors stored in the database.");
                //return false;
            }

            foreach (Doctor doctor in doctorList)
            {
                //Console.WriteLine(patient.Patient_ID);
                if (doctor.DoctorID == ID) { return doctor; }
            }
            
            throw new Exception("Doctor not found.");
            //return false;
        }

        // Print all doctor.ToString() on to screen
        public void PrintAllDoctors()
        {
            if (doctorList.Count == 0)
            {
                Console.WriteLine("No doctor stored in the database. ");
                //return false;
            }

            //Console.WriteLine("Printing all doctor now");

            foreach (Doctor doctor in doctorList)
            {
                //Console.WriteLine("Printing a patient");
                Console.WriteLine(doctor.ToString());
                //if (patient.Patient_ID == ID) { return patient; }
            }
        }

        public void PrintAllDoctors(bool isDifferent)
        {
            if (doctorList.Count == 0)
            {
                Console.WriteLine("No doctor stored in the database. ");
                //return false;
            }

            //Console.WriteLine("Printing all doctor now");

            //foreach (Doctor doctor in doctorList)
            for (int i = 0; i < doctorList.Count; i++)  
            {
                //Console.WriteLine("Printing a patient");
                Console.WriteLine("{0}: {1}", i + 1, doctorList[i].ToString());
                //if (patient.Patient_ID == ID) { return patient; }
            }
        }

        public Doctor GetDoctorByIndex(int i)
        {
            if (doctorList.Count == 0 || i > doctorList.Count)
            {
                throw new Exception("No doctors stored in the database.");
                //return false;
            }

            return doctorList[i - 1];

            /*foreach (Doctor doctor in doctorList)
            {
                //Console.WriteLine(patient.Patient_ID);
                if (doctor.DoctorID == ID) { return doctor; }
            }

            throw new Exception("Doctor not found.");*/
            //return false;
        }

        public bool CheckDoctorExistsByID(string ID)
        {
            if (doctorList.Count == 0 || ID == null)
            {
                //throw new Exception("Patient list is not initialised");
                return false;
            }

            for (int i = 0; i < doctorList.Count; i++)
            {
                if (doctorList[i].DoctorID == ID)
                {
                    //return patientList[i];
                    return true;
                }
            }
            //throw new Exception("Patient not found");
            return false;
        }

        // Adding a new Appointment
        // A new Appointment struct is created and added to the Appointment.txt file

        //public void AddAppointment(string appointment)
        public string AddAppointment(List<string> appointmentDetail)
        {
            bool isDuplicated = true;
            Random rand = new Random();
            string bookingID = "";

            do // Generates an unique booking ID
            {
                /*bookingID = "";
                bookingID += "0";
                bookingID += "0";*/
                //for (int i = 0; i < 5; i++) // Length for bookingID is determined to be 5 for now

                isDuplicated = true;

                bookingID = "";
                bookingID += Convert.ToString(rand.Next(0, 99999));
                //Console.WriteLine(patientID);
                //isDuplicated = CheckPatientExistsByID(patientID);

                if (bookedAppointments.Count == 0)
                {
                    //throw new Exception("Patient list is not initialised");
                    //return false;
                    isDuplicated = false;
                }

                for (int i = 0; i < bookedAppointments.Count; i++)
                {
                    if (bookedAppointments[i].appointmentID == bookingID)
                    {
                        //return patientList[i];
                        //return true;
                        isDuplicated = true;
                        break;
                    }
                    isDuplicated = false;
                }

                
                //throw new Exception("Patient not found");
                //return false;
            }
            while (isDuplicated);

            /*Appointment booking = new Appointment(bookingID, 
                GetPatientByID(appointmentDetail[0]), 
                GetDoctorByID(appointmentDetail[1]), 
                appointmentDetail[2]);*/

            string finalAdding = "\n";
            finalAdding += bookingID;
            finalAdding += ",";

            foreach (string detail in appointmentDetail)
            {
                //Console.WriteLine("{0}", detail);
                finalAdding += detail;
                finalAdding += ",";
            }

            FileManager.AppendAtTheEndOfLine("Patients.txt", appointmentDetail[0], bookingID);

            FileManager.AppendAtTheEndOfLine("Doctors.txt", appointmentDetail[1], bookingID);

            FileManager.AppendToFileEnd("Appointments.txt", finalAdding);

            return bookingID;

            //return patientID;
            /*string patientID = "";
            patientID += "0";
            patientID += "0";*/
            //patientID += Random.Next(0)
        }

        public Appointment GetAppointmentByID(string ID)
        {
            if (bookedAppointments.Count == 0 || ID == null)
            {
                throw new Exception("Currently No Bookings");
                //return false;
            }

            foreach (Appointment appointment in bookedAppointments)
            {
                //Console.WriteLine(patient.Patient_ID);
                if (appointment.appointmentID == ID) { return appointment; }
            }

            /*for (int i = 0; i < patientList.Count; i++)
            {
                if (patientList[i].Patient_ID == ID)
                {
                    return patientList[i];
                    //return true;
                }
            }*/
            throw new Exception("Appointment not found");
        }
        

        /*public Doctor GetDoctorByID(string ID)
        {
            if (doctorList.Count == 0) 
            {
            {
                throw new Exception("Doctor list is not initialised");
            }

            for (int i = 0; i < doctorList.Count; i++)
            {
                if (doctorList[i].DoctorID == ID)
                {
                    return doctorList[i];
                }
            }
            throw new Exception("Doctor not found");
        }*/

        /*public Patient GetPatientByID(string ID)
        {
            if (patientList.Count == 0)
            {
                throw new Exception("Patient list is not initialised");
            }

            for (int i = 0; i < patientList.Count; i++)
            {
                if (patientList[i].Patient_ID == ID)
                {
                    return patientList[i];
                }
            }
            throw new Exception("Patient not found");
        }*/

    }
}
