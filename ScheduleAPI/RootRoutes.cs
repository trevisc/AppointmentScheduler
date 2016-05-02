using Nancy;
using System;
using Nancy.ModelBinding;
using ScheduleAPI.Data.Models;
using ScheduleAPI.Data.Repositories.Impl;
using ScheduleAPI.Data.Repositories;
using System.Collections.Generic;

namespace ScheduleAPI
{
    public class RootRoutes : NancyModule
    {
        public RootRoutes()
        {
            Get["/"] = Index;           
            Get["patient/{id}"] = GetPatientDetails;
            Get["GetAppointmentsByProdiver/{id}/{date}"] = GetAppointmentsByProdivder;
            Get["ScheduleAppointment/{patientId}/{serviceId}/{providerId}/{reason}/{duration}/{datetime}"] = CreateAppointment;
        }

        private dynamic PostTest(dynamic parameters)
        {
            var patient = this.Bind<Patient>();

            return String.Format("Hello there {0} I see that you are {1} years old.",
                           patient.Name, patient.Age);
        }              

        private dynamic Index(dynamic parameters)
        {
            return "Schedule something";
        }
       
        private dynamic GetPatientDetails(dynamic parameters)
        {
            IPatientRepository ipr = new PatientRepository();
            Patient patient = ipr.GetPatientById(parameters.id);
            if (patient != null)
            {
                return Response.AsJson(patient);
            }
            else
            {
                var msg = new
                {
                   message="Patient Not Found."
                };
                return Response.AsJson(msg);
            }
        }

        private dynamic GetAppointmentsByProdivder(dynamic parameters)
        {
            IAppointmentRepository iar = new AppointmentRepository();
            IList<Appointment> appts = iar.GetAppointmentsByProviderId(parameters.id, parameters.date);
            if (appts != null)
            {
                return Response.AsJson(appts);
            }
            else
            {
                var msg = new
                {
                    message = "No Appointments Found."
                };
                return Response.AsJson(msg);
            }
        }

        private dynamic CreateAppointment(dynamic parameters)
        {
            IAppointmentRepository iar = new AppointmentRepository();
            IList<Appointment> appts = iar.GetAppointmentsByProviderId(parameters.id, parameters.date);
            Scheduler sch = new Scheduler();
            ServiceResponse sResponse = new ServiceResponse();
            sResponse = sch.CreateAppointment(parameters.patientId, parameters.serviceId, parameters.providerId, parameters.reason, parameters.duration, parameters.datetime);
            return Response.AsJson(sResponse);
        }
        
    }
}