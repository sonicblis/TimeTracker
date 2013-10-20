using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TimeTracker.API.Models.Domain;

namespace TimeTracker.API.Models.Data
{
    public class TimeTrackerDataContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityGroup> Groups { get; set; }
        public DbSet<ActivityTime> ActivityTimes { get; set; }
        public DbSet<TimedRun> Runs { get; set; }
    }
}