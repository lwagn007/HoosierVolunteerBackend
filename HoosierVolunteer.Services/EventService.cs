
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoosierVolunteer.Contracts;
using HoosierVolunteer.Models;
using HoosierVolunteer.Models.Event;


namespace HoosierVolunteer.Services
{
    public class EventService : IEventService
    {
        private readonly Guid _creatorId;

        public EventService(Guid creatorId)
        {
            _creatorId = creatorId;
        }

        public bool CreateEvent(EventCreate model)
        {
            var entity =
                new Events()
                {
                    CreatorId = _creatorId,
                    EventRange = new DateRange()
                    {
                        Start = model.EventRange.Start,
                        End = model.EventRange.End
                    },
                    Type = (Events.EventType)model.Type,
                    EventTitle = model.EventTitle,
                    VolunteersNeeded = model.VolunteersNeeded,
                    EventDescription = model.EventDescription
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Events.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEquipment(int equipmentId)
        {
            throw new NotImplementedException();
        }

        public EventDetail GetEventById(int eventId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventListItem> GetEvents()
        {
            throw new NotImplementedException();
        }

        public bool UpdateEquipment(EventEdit model)
        {
            throw new NotImplementedException();
        }
    }
}
