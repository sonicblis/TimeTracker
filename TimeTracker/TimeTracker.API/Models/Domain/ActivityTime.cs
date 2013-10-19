using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTracker.API.Models.Domain
{
    public class ActivityTime
    {
        public Guid Id { get; set; }
        public TimeSpan Duration { get; set; }
    }
}