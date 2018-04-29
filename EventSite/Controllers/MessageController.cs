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
    public class MessageController : ApiController
    {
        private EventContext db = new EventContext();

        [Route("messages/{ID}")]
        [HttpGet]
        public IHttpActionResult GetOneMessage(int ID)
        {
            var message = db.Messages.SingleOrDefault(s => s.ID == ID);
            if (message == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(message);
            }
        }

        [Route("messages")]
        [HttpPost]
        public IHttpActionResult AddMessage(Message message)
        {
            db.Messages.Add(message);
            db.SaveChanges();
            return Ok(message);
        }

        [Route("messages/{ID}")]
        [HttpDelete]
        public IHttpActionResult DeleteMessage(int ID)
        {
            var message = db.Messages.SingleOrDefault(s => s.ID == ID);
            db.Messages.Remove(message);
            db.SaveChanges();
            return Ok(message);
        }
    }
}