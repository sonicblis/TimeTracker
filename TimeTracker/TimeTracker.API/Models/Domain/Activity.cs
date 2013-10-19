using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTracker.API.Models.Domain
{
    public class Activity
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
    }
}