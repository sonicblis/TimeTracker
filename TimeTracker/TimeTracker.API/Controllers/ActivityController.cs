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
    public class ActivityController : ApiController
    {
        private TimeTrackerDataContext db = new TimeTrackerDataContext();

        public IQueryable<Activity> GetActivities()
        {
            return db.Activities;
        }

        [ResponseType(typeof(Activity))]
        public IHttpActionResult GetActivity(Guid id)
        {
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
        }

        public IHttpActionResult PutActivity(Guid id, Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activity.Id)
            {
                return BadRequest();
            }

            db.Entry(activity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityExists(id))
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

        [ResponseType(typeof(Activity))]
        public IHttpActionResult PostActivity(Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Activities.Add(activity);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ActivityExists(activity.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = activity.Id }, activity);
        }

        [ResponseType(typeof(Activity))]
        public IHttpActionResult DeleteActivity(Guid id)
        {
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return NotFound();
            }

            db.Activities.Remove(activity);
            db.SaveChanges();

            return Ok(activity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActivityExists(Guid id)
        {
            return db.Activities.Count(e => e.Id == id) > 0;
        }
    }
}