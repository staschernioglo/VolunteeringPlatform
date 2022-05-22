using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringPlatform.Common.Dtos.Volunteer;
using VolunteeringPlatform.Common.Models.PagedRequest;

namespace VolunteeringPlatform.Bll.Interfaces
{
    public interface IVolunteerService
    {
        Task<PaginatedResult<VolunteerListDto>> GetPagedVolunteers(PagedRequest pagedRequest);
        Task ParticipateInProject(int projectId, int volunteerId);
        Task ParticipateInGoodDeed(int goodDeedId, int volunteerId);
    }
}
