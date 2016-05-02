using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScheduleAPI.Data.Models;
using ScheduleAPI.Data.Repositories;
using ScheduleAPI.Data.Repositories.Impl;
using ScheduleAPI;
using System.Collections.Generic;

namespace ScheduleAPI.Test
{

    [TestClass]
    public class TestScheduler
    {
        
        [TestMethod]
        public void ProviderHasHighEnoughCertLevel_ShouldNotHaveHightEnoughLevel()
        {
            IServiceRepository srvRep = new ServiceRepository();
            IProviderRepository proRep = new ProviderRepository();
            Scheduler sched = new Scheduler();
            Provider pro = proRep.GetProviderById("2");
            Service srv = srvRep.GetServiceById("2");          
            Assert.IsFalse(sched.ProviderHasHighEnoughCertLevel(srv,pro));
        }
        [TestMethod]
        public void ProviderHasHighEnoughCertLevel_ShouldHaveHightEnoughLevel()
        {
            IServiceRepository srvRep = new ServiceRepository();
            IProviderRepository proRep = new ProviderRepository();
            Scheduler sched = new Scheduler();
            Provider pro = proRep.GetProviderById("1");
            Service srv = srvRep.GetServiceById("2");
            Assert.IsTrue(sched.ProviderHasHighEnoughCertLevel(srv,pro));
        }
        [TestMethod]
        public void PatientIsOldEnoughForService_IsOldEnough()
        {
            IServiceRepository srvRep = new ServiceRepository();
            IPatientRepository patientRep = new PatientRepository();
            Scheduler sched = new Scheduler();
            Service srv = srvRep.GetServiceById("2");
            Patient patient = patientRep.GetPatientById("1");
            Assert.IsTrue(sched.PatientIsOldEnoughForService(srv,patient));
        }
        [TestMethod]
        public void PatientIsOldEnoughForService_IsNotOldEnough()
        {
            IServiceRepository srvRep = new ServiceRepository();
            IPatientRepository patientRep = new PatientRepository();
            Scheduler sched = new Scheduler();
            Service srv = srvRep.GetServiceById("2");
            Patient patient = patientRep.GetPatientById("5");
            Assert.IsFalse(sched.PatientIsOldEnoughForService(srv, patient));
        }
        [TestMethod]
        public void ProviderIsAvailble_ProviderIsAvailable()
        {
            IServiceRepository srvRep = new ServiceRepository();
            IProviderRepository proRep = new ProviderRepository();
            IAppointmentRepository apptRep = new AppointmentRepository();
            Scheduler sched = new Scheduler();
            Provider pro = proRep.GetProviderById("2");
            Service srv = srvRep.GetServiceById("1");
            IList<Appointment> currentAppts = apptRep.GetAppointmentsByProviderId(pro.Id, "2016-04-15" );
            Assert.IsTrue(sched.ProviderIsAvailable(currentAppts, srv, "2016-04-15 09:40:00 AM"));
        }
        [TestMethod]
        public void ProviderIsAvailble_ProviderIsNotAvailable()
        {
            IServiceRepository srvRep = new ServiceRepository();
            IProviderRepository proRep = new ProviderRepository();
            IAppointmentRepository apptRep = new AppointmentRepository();
            Scheduler sched = new Scheduler();
            Provider pro = proRep.GetProviderById("2");
            Service srv = srvRep.GetServiceById("1");
            IList<Appointment> currentAppts = apptRep.GetAppointmentsByProviderId(pro.Id, "2016-04-15");
            Assert.IsFalse(sched.ProviderIsAvailable(currentAppts, srv, "2016-04-15 09:39:00 AM"));
        }
        [TestMethod]
        public void IsWithinBusinessHours_IsWithinBusinessHours()
        {
            Scheduler sched = new Scheduler();
            Assert.IsTrue(sched.IsWithinBusinessHours("2016-04-15 09:00:00 AM"));
        }
        [TestMethod]
        public void IsWithinBusinessHours_IsNotWithinBusinessHours()
        {
            Scheduler sched = new Scheduler();
            Assert.IsFalse(sched.IsWithinBusinessHours("2016-04-15 08:59:00 AM"));
        }
    }
}
