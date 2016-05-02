using ScheduleAPI.Data.Models;
using System.Collections.Generic;

namespace ScheduleAPI.Data.Repositories
{
    public interface IAppointmentRepository
    {
        IList<Appointment> GetAppointments(string date);
        IList<Appointment> GetAppointmentsByProviderId(string providerId, string date);
        void AddAppointment(Appointment newAppt);
        int FirstAppointmentTime();
        int LastAppointmentTime();
        //add other crud operations as needed in the future
    }
}
