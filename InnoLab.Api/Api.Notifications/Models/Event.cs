using System;

namespace Api.Notifications.Models
{
    public class Event
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Desctription { get; set; }

        public string LogoLocation { get; set; }

        public string Link { get; set; }

        public bool IsDispached { get; set; }
    }
}