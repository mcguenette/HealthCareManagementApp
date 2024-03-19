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

        public List<Doctors> GetAllDoctorsService()
        {
            return dr.GetAllDoctorsRepo();
        }

        public Doctors GetDoctorByIDService(int id)
        {
            return dr.GetDoctorByIDRepo(id);
        }

        public string AddDoctorService(Doctors DoctorFormData)
        {
            return dr.AddDoctor(DoctorFormData);
        }

        public string UpdateDoctorService(Doctors DoctorFormData)
        {
            return dr.UpdateDoctorRepo(DoctorFormData);
        }

        public string DeleteDoctorService(int docID)
        {
            return dr.DeleteDoctorRepo(docID);
        }
    }
}
