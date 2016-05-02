using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleAPI.Data.Models;

namespace ScheduleAPI.Data.Repositories.Impl
{
    public class ServiceRepository : IServiceRepository
    {
        public Service GetServiceById(string id)
        {
            return MockData.GetServices().SingleOrDefault(p => p.Id == id);
        }

        public IList<Service> GetServices()
        {
            return MockData.GetServices();
        }
    }
}
