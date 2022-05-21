using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringPlatform.Domain.Entities;

namespace VolunteeringPlatform.Domain.Auth
{
    public class Organization : User
    {
        public string? Address { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
