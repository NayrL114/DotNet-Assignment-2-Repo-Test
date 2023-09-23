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

        public static Doctor GetDoctorByID(string ID)
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
        }

        public static Patient GetPatientByID(string ID)
        {
            if (patientList.Count == 0)
            {
                throw new Exception("Patient list is not initialised");
            }

            for (int i = 0; i < patientList.Count; i++)
            {
                if (patientList[i].DoctorID == ID)
                {
                    return patientList[i];
                }
            }
            throw new Exception("Patient not found");
        }

        public static bool CheckPatientExistsByID(string ID)
        {
            if (patientList.Count == 0)
            {
                //throw new Exception("Patient list is not initialised");
                return false;
            }

            for (int i = 0; i < patientList.Count; i++)
            {
                if (patientList[i].DoctorID == ID)
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
