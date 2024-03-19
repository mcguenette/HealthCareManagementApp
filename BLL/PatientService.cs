using DAL;
using ENTITIES.Entities;

namespace BLL
{
    public class PatientService
    {
        PatientRepository pr = new PatientRepository();

        public List<Patients> GetAllPatientsService()
        {
            return pr.GetAllPatientsRepo();
        }

        public Patients GetPatientByIDService(int id)
        {
            return pr.GetPatientByIDRepo(id);
        }

        public string AddPatientService(Patients patientFormData)
        {
            return pr.AddPatient(patientFormData);
        }

        public string UpdatePatientService(Patients patientFormData)
        {
            return pr.UpdatePatientRepo(patientFormData);
        }

        public string DeletePatientService(int patID)
        {
            return pr.DeletePatientRepo(patID);
        }
    }
}
