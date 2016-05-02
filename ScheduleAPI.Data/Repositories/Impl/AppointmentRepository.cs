using ScheduleAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleAPI.Data.Repositories.Impl
{
   public class AppointmentRepository : IAppointmentRepository
    {
        public void AddAppointment(Appointment newAppt)
        {
           //TODO: Implement Adding new appointment. 
        }

        public IList<Appointment> GetAppointments(string date)
        {
            if (date == string.Empty)
            {
                return null;
            }
            IList<Appointment> appoints = new List<Appointment>();
            IEnumerable<Appointment> apps = MockData.GetAppointments().Where(a => DateTime.Parse(a.Starts).ToShortDateString() == DateTime.Parse(date).ToShortDateString());
            appoints = apps.ToList();
            return appoints;
        }
        public IList<Appointment> GetAppointmentsByProviderId(string providerId,string date)
        {
            if(providerId == string.Empty || date== string.Empty)
            {
                return null;
            }
            IList<Appointment> appoints = new List<Appointment>();
            IEnumerable<Appointment> apps = MockData.GetAppointments().Where(a => a.ProviderId == providerId && DateTime.Parse(a.Starts).ToShortDateString() == DateTime.Parse(date).ToShortDateString());
            appoints = apps.ToList();
            return appoints;
        }
        public int FirstAppointmentTime()
        {
            return MockData.BeginScheduling();

        }
            public int LastAppointmentTime()
        {
            return MockData.EndScheduling();
        }
    }
}
