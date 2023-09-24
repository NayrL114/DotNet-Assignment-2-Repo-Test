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

        // ALL FUNCTION WAS STATIC IN PREVIOUS UTIL CLASS DESIGN

        public void InitialiseUserData()
        {
            //List<String> adminFileLines = FileManager.ReadStringListFromFile("Admins.txt");
            //List<String> doctorFileLines = FileManager.ReadStringListFromFile("Doctors.txt");
            List<String> patientFileLines = FileManager.ReadStringListFromFile("Patients.txt");

            foreach (String details in patientFileLines)
            {
                string[] detail = details.Split(',');
                Patient patient = new Patient(detail[2], detail);
                patientList.Add(patient);
            }
        }

        public void WipeUserData()
        {
            adminList = new List<Admin>();
            doctorList = new List<Doctor>();
            patientList = new List<Patient>();
        }

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

        public bool CheckPatientExistsByID(string ID)
        {
            // Return TRUE if exists, 
            // Return FALSE if not exists
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

    }
}
