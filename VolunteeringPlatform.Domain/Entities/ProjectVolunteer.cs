﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringPlatform.Domain.Auth;

namespace VolunteeringPlatform.Domain.Entities
{
    public class ProjectVolunteer : BaseEntity
    {
        public int VolunteerId { get; set; }
        public int ProjectId { get; set; }
        public bool Status { get; set; } = false;
        public virtual Volunteer Volunteer { get; set; }
        public virtual Project Project { get; set; }
    }
}
