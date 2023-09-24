using System;
using System.Collections.Generic;
using System.Linq;
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

        // ALL FUNCTION WAS STATIC IN PREVIOUS UTIL CLASS DESIGN

        // Populates all three user lists
        public void InitialiseUserData()
        {
            // If there are already contents inside lists, don't do anything
            if (patientList.Count != 0 && doctorList.Count != 0 && adminList.Count != 0)
            //if (patientList.Count != 0)
            {
                return;
            }

            List<String> adminFileLines = FileManager.ReadStringListFromFile("Admins.txt");
            List<String> doctorFileLines = FileManager.ReadStringListFromFile("Doctors.txt");
            List<String> patientFileLines = FileManager.ReadStringListFromFile("Patients.txt");

            foreach (String details in adminFileLines)
            {
                string[] detail = details.Split(',');
                Admin admin = new Admin(detail[1], detail);
                adminList.Add(admin);
            }

            foreach (String details in doctorFileLines)
            {
                string[] detail = details.Split(',');
                Doctor doctor = new Doctor(detail[1], detail);
                doctorList.Add(doctor);
            }

            foreach (String details in patientFileLines)
            {
                string[] detail = details.Split(',');
                Patient patient = new Patient(detail[1], detail);
                patientList.Add(patient);
            }
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
        // Format is: 00(XXX), where X can be any numbers between 0-9
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
                patientID += "0";
                patientID += Convert.ToString(rand.Next(100, 999));
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
                throw new Exception("Patient list is not initialised");
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
            throw new Exception("Patient not found");
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

            Console.WriteLine("Printing all patient now");

            foreach (Patient patient in patientList)
            {
                //Console.WriteLine("Printing a patient");
                Console.WriteLine(patient.ToString());
                //if (patient.Patient_ID == ID) { return patient; }
            }
        }


        /*public Doctor GetDoctorByID(string ID)
        {
            if (doctorList.Count == 0) 
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
