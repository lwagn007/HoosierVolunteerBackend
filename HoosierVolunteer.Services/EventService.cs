
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
                    EventDescription = model.EventDescription,
                    Created = DateTime.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Events.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EventListItem> GetEvents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Events
                        .Select(
                        e => new EventListItem
                        {
                            EventId = e.EventId,
                            EventRange = new DateRangeModel()
                            {
                                Start = e.EventRange.Start,
                                End = e.EventRange.End,
                            },
                            EventTitle = e.EventTitle,
                            VolunteersNeeded = e.VolunteersNeeded,

                        }
                      );
                return query.ToArray();
            }
        }

        public IEnumerable<EventListItem> GetEventsByOwner()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Events
                        .Where(e=> e.CreatorId == _creatorId)
                        .Select(
                        e => new EventListItem
                        {
                            EventId = e.EventId,
                            EventRange = new DateRangeModel()
                            {
                                Start = e.EventRange.Start,
                                End = e.EventRange.End,
                            },
                            EventTitle = e.EventTitle,
                            VolunteersNeeded = e.VolunteersNeeded,

                        }
                      );
                return query.ToArray();
            }
        }

        public EventDetail GetEventById(int eventId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Events
                    .Single(e => e.EventId == eventId && e.CreatorId == _creatorId);
                return
                    new EventDetail
                    {
                        EventId = entity.EventId,
                        EventTitle = entity.EventTitle,
                        EventRange = new DateRangeModel()
                        {
                            Start = entity.EventRange.Start,
                            End = entity.EventRange.End
                        },
                        VolunteersNeeded = entity.VolunteersNeeded,
                        AttendingVolunteers = entity.AttendingVolunteers,
                        EventDescription = entity.EventDescription,
                    };
            }
        }


        public bool DeleteEvent(int eventId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Events
                        .Single(e => e.EventId == eventId && e.CreatorId == _creatorId);
                ctx.Events.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateEvent(EventEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Events
                    .Single(e => e.EventId == model.EventId && e.CreatorId == _creatorId);

                entity.EventRange = new DateRange()
                {
                    Start = model.EventRange.Start,
                    End = model.EventRange.End
                };
                entity.Type = (Events.EventType)model.Type;
                entity.EventTitle = model.EventTitle;
                entity.VolunteersNeeded = model.VolunteersNeeded;
                entity.EventDescription = model.EventDescription;
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
