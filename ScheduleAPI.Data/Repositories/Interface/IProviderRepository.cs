using ScheduleAPI.Data.Models;
using System.Collections.Generic;


namespace ScheduleAPI.Data.Repositories
{
   public interface IProviderRepository
    {
        Provider GetProviderById(string id);
        IList<Provider> GetProviders();
    }
}
