namespace ScheduleAPI.Data.Models
{
   public  class Appointment
    {
        public string Id { get; set; }
        public string PatientId { get; set; }
        public string ProviderId { get; set; }
        public string ServiceId { get; set; }
        public string ReasonForVisit { get; set; }
        public int PlannedDuration { get; set; }
        public string Starts { get; set; }
    }
}
