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
        Task<PaginatedResult<VolunteerListDto>> GetPagedVolunteersAsync(PagedRequest pagedRequest);
        Task ParticipateInProjectAsync(int projectId, int volunteerId);
        Task ParticipateInGoodDeedAsync(int goodDeedId, int volunteerId);
    }
}
