using ScheduleAPI.Data.Models;
using System.Collections.Generic;

namespace ScheduleAPI.Data.Repositories
{
   public interface IPatientRepository
    {
        IList<Patient> GetPatients();
        Patient GetPatientById(string id);
        //add other crud operations as needed in the future
    }
}
