﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolunteeringPlatform.Common.Dtos.Organization
{
    public class OrganizationListDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? Description { get; set; }
        public string? Locality { get; set; }
    }
}
