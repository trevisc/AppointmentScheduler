namespace ScheduleAPI.Data.Models
{
    public class Service
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int RequiredCertLevel { get; set; }
        public int Duration { get; set; }
        public int RequiredAge { get; set; }
    }
}