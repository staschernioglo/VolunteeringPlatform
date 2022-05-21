using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolunteeringPlatform.Domain.Entities
{
    public class News : BaseEntity
    {
        [MaxLength(200)]
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublicationDate { get; set; }
        public string? ImageUrl { get; set; }
    }
}
