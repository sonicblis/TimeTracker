using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TimeTracker.API.Models.Domain;
using TimeTracker.API.Models.Data;

namespace TimeTracker.API.Controllers
{
    public class ActivityGroupController : ApiController
    {
        private TimeTrackerDataContext db = new TimeTrackerDataContext();

        public IQueryable<ActivityGroup> GetGroups()
        {
            return db.Groups;
        }

        [ResponseType(typeof(ActivityGroup))]
        public IHttpActionResult GetActivityGroup(Guid id)
        {
            ActivityGroup activitygroup = db.Groups.Find(id);
            if (activitygroup == null)
            {
                return NotFound();
            }

            return Ok(activitygroup);
        }

        public IHttpActionResult PutActivityGroup(Guid id, ActivityGroup activitygroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activitygroup.Id)
            {
                return BadRequest();
            }

            db.Entry(activitygroup).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityGroupExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(ActivityGroup))]
        public IHttpActionResult PostActivityGroup(ActivityGroup activitygroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Groups.Add(activitygroup);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ActivityGroupExists(activitygroup.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = activitygroup.Id }, activitygroup);
        }

        [ResponseType(typeof(ActivityGroup))]
        public IHttpActionResult DeleteActivityGroup(Guid id)
        {
            ActivityGroup activitygroup = db.Groups.Find(id);
            if (activitygroup == null)
            {
                return NotFound();
            }

            db.Groups.Remove(activitygroup);
            db.SaveChanges();

            return Ok(activitygroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActivityGroupExists(Guid id)
        {
            return db.Groups.Count(e => e.Id == id) > 0;
        }
    }
}