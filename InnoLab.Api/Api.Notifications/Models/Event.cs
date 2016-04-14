using System;

namespace Api.Notifications.Models
{
    public class Event
    {
        public virtual Guid Id { get; set; }

        public virtual string UserName { get; set; }

        public virtual string Name { get; set; }

        public virtual string Desctription { get; set; }

        public virtual string LogoLocation { get; set; }

        public virtual string Link { get; set; }

        public virtual bool IsDispached { get; set; }
    }
}