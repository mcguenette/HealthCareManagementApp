using DAL;
using ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DoctorService
    {
        DoctorRepository dr = new DoctorRepository();

        public List<Doctor> GetAllDoctorsService()
        {
            return dr.GetAllDoctorsRepo();
        }

        public Doctor GetDoctorByIDService(int id)
        {
            return dr.GetDoctorByIDRepo(id);
        }

        public string AddDoctorService(Doctor DoctorFormData)
        {
            return dr.AddDoctor(DoctorFormData);
        }

        public string UpdateDoctorService(Doctor DoctorFormData)
        {
            return dr.UpdateDoctorRepo(DoctorFormData);
        }

        public string DeleteDoctorService(int docID)
        {
            return dr.DeleteDoctorRepo(docID);
        }
    }
}
