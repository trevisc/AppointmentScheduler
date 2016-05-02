using System;
using Nancy.Hosting.Self;

namespace ScheduleAPI
{
    class Program
    {
        static void Main()
        {
            var hostConfiguration = new HostConfiguration
            {
                UrlReservations = new UrlReservations() { CreateAutomatically = true }
            };
            using (var host = new NancyHost(hostConfiguration, new Uri("http://localhost:2016")))
            {
                host.Start();
                Console.WriteLine("Running on http://localhost:2016");
                Console.ReadLine();
            }

        }

    }
}