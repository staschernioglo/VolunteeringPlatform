using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringPlatform.Domain.Entities;

namespace VolunteeringPlatform.Domain.Auth
{
    public class Volunteer : User
    {
        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }
        public int NumberOfParticipations { get; set; } = 0;
        public virtual ICollection<ProjectVolunteer> ProjectVolunteers { get; set; }
        public virtual ICollection<GoodDeedVolunteer> GoodDeedVolunteers { get; set; }
    }
}
