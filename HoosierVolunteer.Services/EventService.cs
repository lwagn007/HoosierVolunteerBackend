using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HoosierVolunteer.Contracts;
using HoosierVolunteer.Models;
using HoosierVolunteer.Models.Event;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;


namespace HoosierVolunteer.Services
{
    public class EventService : IEventService
    {
        private readonly Guid _creatorId;

        public EventService(Guid creatorId)
        {
            _creatorId = creatorId;
        }

        public Result GetLocationData(string address)
        {
            string LocationData = getLocationData(address);
            Result LocationObject = DeserializeLocationData(LocationData);
            return LocationObject;
        }

        public Result DeserializeLocationData(string SerializedData)
        {
            var LocationData = JsonConvert.DeserializeObject<RootObject>(SerializedData);
            return LocationData.results[LocationData.results.Count - 1];
        }

        private static String getLocationData(string address)
        {
            using (var client = new HttpClient())
            {
                string requestUrl = "https://maps.googleapis.com/maps/api/geocode/json?address=" + address.Replace(' ', '+') + "&key=AIzaSyAZZA66wU6vz39Jc2WY5uiD4eWygYNg2RM";


                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
                webRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public bool CreateEvent(EventCreate model)
        {
            Result LocationData = GetLocationData(model.Address);
            var entity =
                new Events()
                {
                    CreatorId = _creatorId,
                    EventRange = new DateRange()
                    {
                        Start = model.Start,
                        End = model.End
                    },
                    Type = (Events.EventType)model.Type,
                    EventTitle = model.EventTitle,
                    Address = model.Address,
                    Latitude = LocationData.geometry.location.lat.ToString(),
                    Longitude = LocationData.geometry.location.lng.ToString(),
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
                            Start = e.EventRange.Start,
                            End = e.EventRange.End,
                            Type = (int)e.Type,
                            EventTitle = e.EventTitle,
                            VolunteersNeeded = e.VolunteersNeeded,
                            Latitude = e.Latitude,
                            Longitude = e.Longitude,
                            Address = e.Address

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
                        .Where(e => e.CreatorId == _creatorId)
                        .Select(
                        e => new EventListItem
                        {
                            EventId = e.EventId,
                            Start = e.EventRange.Start,
                               End = e.EventRange.End,
                            EventTitle = e.EventTitle,
                            VolunteersNeeded = e.VolunteersNeeded,
                            Latitude = e.Latitude,
                            Longitude = e.Longitude,
                            Address = e.Address
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
                        Start = entity.EventRange.Start,
                        End = entity.EventRange.End,
                        VolunteersNeeded = entity.VolunteersNeeded,
                        AttendingVolunteers = entity.AttendingVolunteers,
                        EventDescription = entity.EventDescription,
                        Latitude = entity.Latitude,
                        Longitude = entity.Longitude,
                        Address = entity.Address
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
            Result LocationData = GetLocationData(model.Address);
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
                entity.Address = model.Address;
                entity.Latitude = LocationData.geometry.location.lat.ToString();
                entity.Longitude = LocationData.geometry.location.lng.ToString();
                entity.VolunteersNeeded = model.VolunteersNeeded;
                entity.EventDescription = model.EventDescription;
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
