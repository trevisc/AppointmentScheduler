using ScheduleAPI.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleAPI.Data.Repositories.Impl
{
    public class PatientRepository : IPatientRepository
    {
        public Patient GetPatientById(string id)
        {
            return MockData.GetPatients().SingleOrDefault(p => p.Id == id);          
        }

        public IList<Patient> GetPatients()
        {
            return MockData.GetPatients();
        }
    }
}
