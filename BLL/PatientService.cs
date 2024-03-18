using DAL;
using ENTITIES.Entities;

namespace BLL
{
    public class PatientService
    {
        PatientRepository pr = new PatientRepository();

        public List<Patient> GetAllPatientsService()
        {
            return pr.GetAllPatientsRepo();
        }

        public Patient GetPatientByIDService(int id)
        {
            return pr.GetPatientByIDRepo(id);
        }

        public string AddPatientService(Patient patientFormData)
        {
            return pr.AddPatient(patientFormData);
        }

        public string UpdatePatientService(Patient patientFormData)
        {
            return pr.UpdatePatientRepo(patientFormData);
        }

        public string DeletePatientService(int patID)
        {
            return pr.DeletePatientRepo(patID);
        }
    }
}
