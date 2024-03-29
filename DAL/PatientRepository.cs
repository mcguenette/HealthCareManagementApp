﻿using ENTITIES.Context;
using ENTITIES.Entities;

namespace DAL
{
    public class PatientRepository
    {
        PatientBookingContext pbc = new PatientBookingContext();

        public List<Patients> GetAllPatientsRepo()
        {
            return pbc.Patients.ToList();
        }

        public string AddPatient(Patients patientFormData)
        {
            if (patientFormData != null)
            {
                pbc.Patients.Add(patientFormData);
                pbc.SaveChanges();
                return "success";
            }
            return "error";
        }
        public Patients GetPatientByIDRepo(int id)
        {
            return pbc.Patients.FirstOrDefault(x => x.PatientID == id);
        }

        public string UpdatePatientRepo(Patients patientFormData)
        {
            Patients pacToBeUpdated = pbc.Patients.FirstOrDefault(x => x.PatientID == patientFormData.PatientID);

            if (pacToBeUpdated != null)
            {
                pacToBeUpdated.PatientName = patientFormData.PatientName;
                pacToBeUpdated.Email = patientFormData.Email;
                pacToBeUpdated.PhoneNumber = patientFormData.PhoneNumber;
                pacToBeUpdated.DOB = patientFormData.DOB;

                //Mapper.Map(pac, pacToBeUpdated); Using automapper is only one line
                pbc.SaveChanges();
                return "success";
            }
            return "error";
        }

        public string DeletePatientRepo(int patID)
        {
            var response = "";
            try
            {
                Patients pacToBeDeleted = pbc.Patients.FirstOrDefault(x => x.PatientID == patID);
                if (pacToBeDeleted != null)
                {
                    pbc.Patients.Remove(pacToBeDeleted);
                    pbc.SaveChanges();
                    response = "success";
                }
                else
                {
                    response = "error: Patient not found";
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
