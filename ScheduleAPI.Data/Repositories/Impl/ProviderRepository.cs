using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleAPI.Data.Models;

namespace ScheduleAPI.Data.Repositories.Impl
{
    public class ProviderRepository : IProviderRepository
    {
        public Provider GetProviderById(string id)
        {
            return MockData.GetProviders().SingleOrDefault(p => p.Id == id);
        }

        public IList<Provider> GetProviders()
        {
            return MockData.GetProviders();
        }
    }
}
