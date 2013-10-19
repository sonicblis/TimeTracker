using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTracker.API.Models.Domain
{
    public class TimedRun
    {
        public Guid Id { get; set; }
        public DateTime DateCaptured { get; set; }
    }
}