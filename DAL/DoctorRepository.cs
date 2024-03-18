using ENTITIES.Context;
using ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DoctorRepository
    {

        PatientBookingContext pbc = new PatientBookingContext();

        public List<Doctor> GetAllDoctorsRepo()
        {
            return pbc.Doctors.ToList();
        }

        public string AddDoctor(Doctor doctorFormData)
        {
            if (doctorFormData != null)
            {
                pbc.Doctors.Add(doctorFormData);
                pbc.SaveChanges();
                return "success";
            }
            return "error";
        }
        public Doctor GetDoctorByIDRepo(int id)
        {
            return pbc.Doctors.FirstOrDefault(x => x.DoctorID == id);
        }

        public string UpdateDoctorRepo(Doctor doctorFormData)
        {
            Doctor docToBeUpdated = pbc.Doctors.FirstOrDefault(x => x.DoctorID == doctorFormData.DoctorID);

            if (docToBeUpdated != null)
            {
                docToBeUpdated.DoctorName = docToBeUpdated.DoctorName;
                docToBeUpdated.DoctorEmail = docToBeUpdated.DoctorEmail;
                docToBeUpdated.DoctorSpecialization = docToBeUpdated.DoctorSpecialization;

                pbc.SaveChanges();
                return "success";
            }
            return "error";
        }

        public string DeleteDoctorRepo(int docID)
        {
            var response = "";
            try
            {
                Doctor docToBeDeleted = pbc.Doctors.FirstOrDefault(x => x.DoctorID == docID);
                if (docToBeDeleted != null)
                {
                    pbc.Doctors.Remove(docToBeDeleted);
                    pbc.SaveChanges();
                    response = "success";
                }
                else
                {
                    response = "error: Doctor not found";
                }
            }
            catch (Exception ex)
            {
                response = $"error: {ex.Message}";
            }
            return response;
        }
    }
}
