using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventSite.Context;
using EventSite.Models;
using System.Data.Entity;

namespace EventSite.Controllers
{
    public class EventController : ApiController
    {
        private EventContext db = new EventContext();

        [Route("events/search")]
        [HttpGet]
        public IQueryable<Models.Event> GetEvents(string query, string ageGroup)
        {
            var ageGroupQuery = (AgeGroup)Enum.Parse(typeof(AgeGroup), ageGroup);

            return db.Events.Include(i => i.AttendeeList).Where(w => w.Title.ToLower().Contains(query.ToLower()) || 
            w.Tagline.ToLower().Contains(query.ToLower()) ||
            w.Price == query || 
            w.Description.ToLower().Contains(query.ToLower()) ||
            w.KeyWord.ToLower().Contains(query.ToLower()) ||
            w.AgeGroup == ageGroupQuery);
        }

        [Route("events/searchbydate")]
        [HttpGet]
        public IQueryable<Models.Event> GetEventsByDate(DateTime query)
        {
            return db.Events.Include(i => i.AttendeeList).Include(i => i.UsersWaitlist).Include(i => i.Comments).Where(w => w.Date.Year == query.Year && w.Date.Month == query.Month && w.Date.Day == query.Day);
        }


        [Route("events")]
        [HttpGet]
        public IEnumerable<Event> GetAllEvents()
        {
            return db.Events.OrderBy(o => o.Title).ToList();
        }

        [Route("events/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetOneEvent(int id)
        {
            var @event = db.Events.Include(i => i.AttendeeList).Include(i => i.UsersWaitlist).Include(i => i.Comments).SingleOrDefault(s => s.Id == id);
            if (@event == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(@event);
            }
        }


        [Route("events/{ID}/attendees")]
        [HttpPost]
        public IHttpActionResult AddAttendee(int ID, string email)
        {
            var attending = db.Users.FirstOrDefault(f => f.Email == email);
            if (attending == null)
            {
                attending = new User { Email = email };
                db.Users.Add(attending);
                db.SaveChanges();
            }
            var @event = db.Events.SingleOrDefault(s => s.Id == ID);
            @event.AttendeeList.Add(attending);
            db.SaveChanges();
            return Ok();
        }


        [Route("events/{ID}/attendees")]
        [HttpDelete]
        public IHttpActionResult RemoveAttendee(int ID, string email)
        {
            var unattending = db.Users.First(f => f.Email == email);
            if (unattending == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            var @event = db.Events.SingleOrDefault(s => s.Id == ID);
            @event.AttendeeList.Remove(unattending);
            db.SaveChanges();
            var waitlist = @event.UsersWaitlist.FirstOrDefault();
            if(waitlist != null)
            {
                @event.UsersWaitlist.Remove(waitlist);
                @event.AttendeeList.Add(waitlist);
                db.SaveChanges();

            }
            return Ok();
        }

       
        [Route("events")]
        [HttpPost]
        public IHttpActionResult AddEvent(Event ev)
        {
            db.Events.Add(ev);
            db.SaveChanges();
            return Ok(ev);
        }


        [Route("events/{ID}/comments")]
        [HttpPost]
        public IHttpActionResult AddComment(int ID, Comment comment)
        {
            var @event = db.Events.SingleOrDefault(s => s.Id == ID);
            @event.Comments.Add(comment);
            db.SaveChanges();
            return Ok();
        }

        [Route("events/{ID}/waitlist")]
        [HttpPost]
        public IHttpActionResult AddWaitlist(int ID, Comment comment)
        {
            return Ok();
        }
    }
}

