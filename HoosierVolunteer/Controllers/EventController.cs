using HoosierVolunteer.Models.Event;
using HoosierVolunteer.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HoosierVolunteer.Controllers
{
    [Authorize]
    [RoutePrefix("api/Event")]
    public class EventController : ApiController
    {
        // POST api/Event/Create
        [HttpPost]
        public IHttpActionResult Create(EventCreate e)
        {
           if (!ModelState.IsValid)
               return BadRequest(ModelState);
            var service = CreateEventService();

           if (!service.CreateEvent(e))
               return InternalServerError();

           return Ok();
        }

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            EventService eventService = CreateEventService();
            var events = eventService.GetEvents();

            return Ok(events);
        }

        // GET api/Event/GetEventById
        [HttpGet]
        [Route("GetEventById")]
        public IHttpActionResult GetEventById(int id)
        {
            EventService eventService = CreateEventService();
            var e = eventService.GetEventById(id);

            return Ok(e);
        }

        // PUT api/Event/Update
        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update(EventEdit e)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateEventService();

            if (!service.UpdateEvent(e))
                return InternalServerError();

            return Ok();
        }

        // DELETE api/Event/Delete
        [Route("Delete")]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateEventService();

            if (!service.DeleteEvent(id))
                return InternalServerError();

            return Ok();
        }

        private EventService CreateEventService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new EventService(userId);
            return noteService;
        }


    }
}