using ScheduleAPI.Data.Models;
using ScheduleAPI.Data.Repositories;
using ScheduleAPI.Data.Repositories.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAPI
{
    public class Scheduler
    {
       public ServiceResponse CreateAppointment(string patientId,string serviceId,string providerId,string reason,string duration,string datetime)
        {
            IAppointmentRepository iar = new AppointmentRepository();
            IPatientRepository ipr = new PatientRepository();
            IProviderRepository ipror = new ProviderRepository();
            IServiceRepository isr = new ServiceRepository();
            ServiceResponse sResponse = new ServiceResponse();
            Patient patient = ipr.GetPatientById(patientId);
            Service service = isr.GetServiceById(serviceId);
            Provider provider = ipror.GetProviderById(providerId);
            IList<Appointment> currentAppts = iar.GetAppointmentsByProviderId(providerId, datetime);
            sResponse.ResponseMessage = new List<string>();

            //Provider has high enough cert level to provide service
            if (!ProviderHasHighEnoughCertLevel(service, provider))
            {
                sResponse.ResponseMessage.Add("Provider selected does not have high enough certification level.");
            }

            //Patient is old enough to have service performed
            if (!PatientIsOldEnoughForService(service, patient))
            {
                sResponse.ResponseMessage.Add("Patient is not old enough for this service.");
            }

            //Can only schedule between 9 and 4
            if (!IsWithinBusinessHours(datetime))
            {
                sResponse.ResponseMessage.Add("Scheduled time is outside of normal business hours.");
            }  
            
            //Provider is available
            if(!ProviderIsAvailable(currentAppts,service,datetime))
            {
                sResponse.ResponseMessage.Add("Provider is not available to perform this service");
            }      
            
            if(sResponse.ResponseMessage.Count > 0)
            {
                sResponse.ResponseCode = "999";
                sResponse.ServiceName = "Create Appointment";
            }
            else
            {
                sResponse.ResponseCode = "200";
                sResponse.ResponseMessage.Add("Appointment Scheduled Successfully.");
                sResponse.ServiceName = "Create Appointment";
            }       
           
            return sResponse;
        }

        public bool ProviderIsAvailable(IList<Appointment> currentAppts, Service service, string datetime)
        {
            DateTime appointmentStart = DateTime.Parse(datetime);
            DateTime appointmentEnd = appointmentStart.AddMinutes(service.Duration);
            bool isAvailable = false;
            foreach (Appointment app in currentAppts)
            {
                DateTime thisAppStart = DateTime.Parse(app.Starts).AddMinutes(-5);
                DateTime thisAppEnd = DateTime.Parse(app.Starts).AddMinutes(app.PlannedDuration).AddMinutes(+5);
                isAvailable = (appointmentEnd.CompareTo(thisAppStart) <= 0) || (appointmentStart.CompareTo(thisAppEnd) >= 0);
            }
            
            return isAvailable;
        }

        public bool IsWithinBusinessHours(string datetime)
        {
            IAppointmentRepository iar = new AppointmentRepository();
            int begTime = iar.FirstAppointmentTime();
            int endTime = iar.LastAppointmentTime();
            DateTime schedTime = DateTime.Parse(datetime);            
            TimeSpan start = new TimeSpan(begTime, 0, 0);
            TimeSpan end = new TimeSpan(endTime, 0, 0);
            TimeSpan now = schedTime.TimeOfDay;
            return (now >= start) && (now <= end);
        }

        public bool PatientIsOldEnoughForService(Service service, Patient patient)
        {
            return patient.Age >= service.RequiredAge;
        }

        public bool ProviderHasHighEnoughCertLevel(Service service, Provider provider)
        {
           return service.RequiredCertLevel <= provider.CertificationLevel;
        }
    }   
}
