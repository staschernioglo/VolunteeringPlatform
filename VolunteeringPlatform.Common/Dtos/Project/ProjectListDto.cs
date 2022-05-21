using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringPlatform.Domain.Auth;
using VolunteeringPlatform.Domain.Entities;

namespace VolunteeringPlatform.Common.Dtos.Project
{
    public class ProjectListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime? Date { get; set; }
        public string? Locality { get; set; }
        public int? RequiredNumberOfVolunteers { get; set; }
        public int NumberOfParticipatingVolunteers { get; set; } = 0;
        public string Organization { get; set; }
    }
}
