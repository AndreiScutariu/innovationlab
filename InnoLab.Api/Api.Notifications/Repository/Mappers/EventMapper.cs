using Api.Notifications.Models;
using FluentNHibernate.Mapping;

namespace Api.Notifications.Repository.Mappers
{
    public class EventMapper : ClassMap<Event>
    {
        public EventMapper()
        {
            Id(x => x.Id);

            Map(x => x.Desctription);
            Map(x => x.Link);
            Map(x => x.LogoLocation);
            Map(x => x.IsDispached);
            Map(x => x.UserName);
            Map(x => x.Name);
        }    
    }
}