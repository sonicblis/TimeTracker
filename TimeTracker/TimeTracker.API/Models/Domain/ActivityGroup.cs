using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTracker.API.Models.Domain
{
    public class ActivityGroup
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public List<Activity> Activities { get; set; }
        public List<TimedRun> Runs { get; set; }
    }
}