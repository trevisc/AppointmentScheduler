using ScheduleAPI.Data.Models;
using System.Collections.Generic;


namespace ScheduleAPI.Data.Repositories
{
   public interface IServiceRepository
    {
        Service GetServiceById(string id);
        IList<Service> GetServices();
    }
}
