using ScheduleAPI.Data.Models;
using System.Collections.Generic;

namespace ScheduleAPI.Data
{
   public static class MockData
    {
        public static IList<Appointment> GetAppointments()
        {
            IList<Appointment> Appointments = new List<Appointment>()
            {
                new Appointment() {Id="1",PatientId= "1", ProviderId="2", ServiceId="4", ReasonForVisit = "Got The Hives", PlannedDuration= 20, Starts= "04/15/2016 09:00:00 AM" },
                new Appointment() {Id="2",PatientId= "2", ProviderId="2", ServiceId="1", ReasonForVisit = "Sick", PlannedDuration= 10, Starts= "04/15/2016 09:25:00 AM" },
                new Appointment() {Id="3",PatientId= "3", ProviderId="1", ServiceId="5", ReasonForVisit = "Fell down stairs", PlannedDuration= 45, Starts= "04/15/2016 15:00:00 PM" },
                new Appointment() {Id="4",PatientId= "5", ProviderId="3", ServiceId="3", ReasonForVisit = "Sports Physical", PlannedDuration= 10, Starts= "04/15/2016 10:00:00 AM" }
            };

            return Appointments;
        }

        public static IList<Patient> GetPatients() 
        {
            IList<Patient> Patients = new List<Patient>()
            {
                new Patient() {Id = "1", Name="Mike Trout", Age=24 },
                new Patient() {Id = "2", Name="Bryce Harper", Age=23 },
                new Patient() {Id = "3", Name="Nolan Ryan", Age=65 },
                new Patient() {Id = "4", Name="Miguel Cabrera", Age=40 },
                new Patient() {Id = "5", Name="Justus Crockett", Age=9 }
            };

            return Patients;
        }

        public static IList<Provider> GetProviders()
        {
            IList<Provider> Providers = new List<Provider>()
            {
                new Provider() {Id = "1",Name="Leonard Mccoy", CertificationLevel = 10},
                new Provider() {Id = "2",Name="Doogie Howser", CertificationLevel = 4},
                new Provider() {Id = "3",Name="Quincy Adams", CertificationLevel = 6},
                new Provider() {Id = "4",Name="Iwana Feelgood", CertificationLevel = 7},
                new Provider() {Id = "5",Name="Jane Sickclair", CertificationLevel = 3}
            };
            return Providers;
        }
        public static IList<Service> GetServices()
        {
            IList<Service> Services = new List<Service>()
            {
                new Service() {Id="1", Name="General Sick Visit", RequiredAge=3, Duration= 10, RequiredCertLevel=3},
                new Service() {Id="2", Name="Open Wound Minor", RequiredAge=12, Duration= 20, RequiredCertLevel=5},
                new Service() {Id="3", Name="Open Wound Major", RequiredAge=18, Duration= 30, RequiredCertLevel=7},
                new Service() {Id="4", Name="Cardiac Palpatation Test", RequiredAge=50, Duration= 45, RequiredCertLevel=8},
                new Service() {Id="5", Name="After 40 Physical", RequiredAge=40, Duration= 60, RequiredCertLevel=3}
            };
            return Services;
        }
        public static int BeginScheduling()
        {
            return 9;
        }
        public static int EndScheduling()
        {
            return 16;
        }
    }
}
