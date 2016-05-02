using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAPI
{
    public class ServiceResponse
    {
        public string ServiceName { get; set; }
        public string ResponseCode { get; set; }
        public IList<string> ResponseMessage { get; set; }
    }
}
